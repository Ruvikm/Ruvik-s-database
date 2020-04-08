package 实验二图书销售系统.物品;

import java.util.ArrayList;
import java.util.List;

//跟实体类相关的操作都封装在这个类中
public class BookList {
    private static List<Book> books = new ArrayList<Book>();
    private static BookList BookShelf = new BookList();

    static {
        Book book1 = new Book();
        Book book2 = new Book();
        Book book3 = new Book();
        Book book4 = new Book();
        Book book5 = new Book();
        Create_book(book1, 10001, "Predictably Irrational", "Dan Ariely", "2008-10-02", 39, 99);
        Create_book(book2, 10002, "Emotional Intelligence", "Daniel Gorman", "2010-11-08", 58, 360);
        Create_book(book3, 10003, "Nudge", "Richard H. Taylor / Cas H. Sunstein", "2009-12-25", 39, 280);
        Create_book(book4, 10004, "Plutocrats", "Chrystia Freeland", "2013-11-11", 58, 288);
        Create_book(book5, 10005, " Poor Economics", "Abhijit V.Banerjee/Esther Duflo", "2013-04-01", 58, 62);
    }

    public static void Create_book(Book Book_, int Id, String Name, String Author, String Date, int Price, int Store) {
        Book_.setId(Id);
        Book_.setName(Name);
        Book_.setAuthor(Author);
        Book_.setPub_date(Date);
        Book_.setPrice(Price);
        Book_.setStore(Store);
        books.add(Book_);
    }

    //构造方法私有化，限制类外创建对象
    private BookList() {
        // TODO Auto-generated constructor stub

    }

    //通过共有的静态方法提供给调用者，从而获取本类的对象
    public static BookList getInstance() {
        return BookShelf;
    }

    //图书入库
    public Boolean InBook(int Book_id, int num) {

        //只能对原有图书进行入库,num——图书入库数量
        boolean flag = false;
        for (int i = 0; i < books.size(); i++) {

            Book temp = books.get(i);
            if (temp.getId() == Book_id) {
                flag = true;
                temp.setStore(temp.getStore() + num);
                break;
            }
        }
        if (!flag) {
            System.out.println("要入库的书在库存中不存在！");
        }
        return flag;
    }

    //图书出库
    public boolean OutBook(int Book_id, int num) {

        boolean Flag = false;
        for (int i = 0; i < books.size(); i++) {

            Book temp = books.get(i);
            if (temp.getId() == Book_id) {
                Flag = true;
                int Current_Num = temp.getStore();
                if (Current_Num - num >= 0) {
                    temp.setStore(Current_Num - num);
                } else {
                    System.out.println("出库数量大于当前数量！");
                    return false;
                }
                break;
            }
        }
        if (!Flag) {
            System.out.println("要出库的书在库存中不存在！");
        }
        return Flag;
    }

    //新增图书
    public void NewBook(Book book, int Id, String Name, String Author, String Date, int Price, int Store) {
        Create_book(book, Id, Name, Author, Date, Price, Store);
    }

    //查询所有图书
    public List<Book> getAll() {

        return books;
    }

    //根据id查找图书
    public Book getById(int Book_id) {

        for (int i = 0; i < books.size(); i++) {

            Book temp = books.get(i);
            if (temp.getId() == Book_id) {
                return temp;
            }
        }
        System.out.println("图书不存在！");
        return null;
    }

    //购买图书检查
    public Book BuyBook(int Book_id, int num) {

        for (int i = 0; i < books.size(); i++) {

            Book temp = books.get(i);
            if (temp.getId() == Book_id) {
                int Current_Num = temp.getStore();
                if (Current_Num - num >= 0) {
                    temp.setStore(Current_Num - num);
                    return temp;
                } else {
                    System.out.println("购买数量大于当前数量！");
                    return null;
                }
            }
        }
        System.out.println("要购买的书在库存中不存在！");
        return null;
    }

    //购买附赠品
    public EX BuyEx(int ExCode) {

        return EXFactory.Create(ExCode);
    }

    //获得所有附赠品信息
    public static List<String> getExNames() {
        return EXFactory.getEXList();
    }

    //购买图书，返回总价
    public int CheckOut(List<Book> bookList,List<Integer> Nums) {

        int sum=0;
        for(int i=0;i<bookList.size();i++){
            Book item=bookList.get(i);
            int num= Nums.get(i);
            sum+=item.getPrice()*num;
        }
        return sum;
    }

}
