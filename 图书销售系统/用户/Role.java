package 实验二图书销售系统.用户;

import 实验二图书销售系统.接口.IAdmin;
import 实验二图书销售系统.接口.ICustomer;
import 实验二图书销售系统.物品.Book;
import 实验二图书销售系统.物品.EX;

import java.util.List;

public class Role {

    private ICustomer Cus = null;
    private IAdmin Adm = null;
    private String Decription;

    public Role(String Decription) {
        super();
        this.Decription = Decription;
        if ("Admin".equals(Decription))
            Adm = new AdminImpl();
        else if ("Customer".equals(Decription))
            Cus = new CustomerImpl();
    }

    public void In(int Book_id, int num) {
        if (Adm == null) {
            System.out.println("您没有库存管理员权限！");
            return;
        }
        Adm.In(Book_id, num);
    }

    public void Out(int Book_id, int num) {
        if (Adm == null) {
            System.out.println("您没有库存管理员权限！");
            return;
        }
        Adm.Out(Book_id, num);
    }

    public void Save(Book book, int Id, String Name, String Author, String Date, int Price, int Store) {
        if (Adm == null) {
            System.out.println("您没有库存管理员权限！");
            return;
        }
        Adm.Save(book,Id,Name,Author,Date,Price,Store);
    }

    public List<Book> query() {
        if (Adm == null && Cus == null) {
            System.out.println("您还没有登录，请登录后再操作！");
            return null;
        } else if (Cus != null) {
            return Cus.query();
        } else return Adm.query();
    }

    public int Checkout(List<Book> bookList,List<Integer> Nums) {
        if (Cus == null) {
            System.out.println("您还没有登录，请登录后再操作！");
            return 0;
        }
        return Cus.CheckOut(bookList, Nums);
    }

    public Book Buy(int Book_id, int num) {
        if (Cus == null) {
            System.out.println("您还没有登录，请登录后再操作！");
            return null;
        }
        return Cus.Buy(Book_id, num);
    }

    public EX BuyEx(int Excode) {
        if (Cus == null) {
            System.out.println("您还没有登录，请登录后再操作！");
            return null;
        }
        return Cus.BuyEx(Excode);
    }

    public List<String> getEXInfo(){
        if (Cus == null) {
            System.out.println("您还没有登录，请登录后再操作！");
            return null;
        }
        return Cus.getEXInfo();
    }

    public Book getById(int Book_id){
        if (Cus == null) {
            System.out.println("您还没有登录，请登录后再操作！");
            return null;
        }
        return Cus.getById(Book_id);
    }

}
