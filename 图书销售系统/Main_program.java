package 实验二图书销售系统;

/*完成买书流程
* 完成控制台上显示的交互过程*/

/**
 管理员账号：Admin    密码：123456
 客户账号：Customer   密码：123456
**/

import 实验二图书销售系统.物品.Book;
import 实验二图书销售系统.用户.User;

import java.util.ArrayList;
import java.util.Scanner;
import java.util.List;

public class Main_program {


    public List<List<String>> data = new ArrayList<>();
    public static List<Book> Buy_List = new ArrayList<Book>();
    public static List<Integer> Buy_Num = new ArrayList<Integer>();

    public static void main(String[] args) {
        String UserName, PassWord;
        User user = new User();
        Scanner scanner = new Scanner(System.in);
        while (true) {
            switch (Begin_Menu()) {
                case 1: {
                    System.out.println("请输入管理员的用户名和密码(用空格分开)");
                    UserName = scanner.next();
                    PassWord = scanner.next();
                    if (user.Sign_in(UserName, PassWord)) {
                        while (Execute(UserName, Function_Menu(UserName), user)) ;
                    }
                    break;
                }
                case 2: {
                    System.out.println("请输入客户的用户名和密码(用空格分开)");
                    UserName = scanner.next();
                    PassWord = scanner.next();
                    if (user.Sign_in(UserName, PassWord)) {
                        while (Execute(UserName, Function_Menu(UserName), user)) ;
                    }
                    break;
                }
                case 0:
                    return;
            }

        }
    }

    public static void ShowAllBooks(List<Book> Book_List) {
        List<List<String>> data = new ArrayList<>();
        data.add(new ArrayList<String>() {{
            add("Book number");
            add("Book name");
            add("Book author");
            add("Publication date");
            add("Book price");
            add("Book inventory");
        }});
        for (int i = 0; i < Book_List.size(); i++) {
            Book t = (Book) Book_List.get(i);
            data.add(new ArrayList<String>() {{
                add(String.valueOf(t.getId()));
                add(t.getName());
                add(t.getAuthor());
                add(t.getPub_date());
                add(String.valueOf(t.getPrice()));
                add(String.valueOf(t.getStore()));
            }});
        }
        new Main_program(data).println(8);
    }

    public static int Function_Menu(String UserName) {
        Scanner scanner = new Scanner(System.in);
        int Choice;
        if (UserName.equals("Admin")) {
            System.out.println("1.入库");
            System.out.println("2.出库");
            System.out.println("3.新增图书");
            System.out.println("4.查询所有图书");
            System.out.println("0.登出");
            for (; ; ) {
                Choice = scanner.nextInt();
                if (Choice >= 0 && Choice <= 4) {
                    break;
                } else {
                    System.out.println("输入选择错误，请重新选择 0--4：");
                }
            }
            return Choice;

        } else if (UserName.equals("Customer")) {
            System.out.println("1.查询图书");
            System.out.println("2.购买图书");
            System.out.println("3.查询附赠品信息");
            System.out.println("4.购买附赠品");
            System.out.println("5.结账");
            System.out.println("0.登出");
            for (; ; ) {
                Choice = scanner.nextInt();
                if (Choice >= 0 && Choice <= 5) {
                    break;
                } else {
                    System.out.println("输入选择错误，请重新选择 0--5：");
                }
            }
            return Choice;

        } else {
            System.out.println("无法登陆");
            return -1;
        }
    }

    public static int Begin_Menu() {
        int Choice;
        Scanner scanner = new Scanner(System.in);
        System.out.println("1.管理员登录");
        System.out.println("2.客户登录");
        System.out.println("0.退出系统");
        for (; ; ) {
            Choice = scanner.nextInt();
            if (Choice >= 0 && Choice <= 2) {
                break;
            } else {
                System.out.println("输入选择错误，请重新选择 0--2：");
            }
        }
        return Choice;
    }

    public static void ShowBuyBooks(List<Book> Book_List, List<Integer> Nums) {
        List<List<String>> data = new ArrayList<>();
        data.add(new ArrayList<String>() {{
            add("Book number");
            add("Book name");
            add("Book price");
            add("Book Num");
        }});
        for (int i = 0; i < Book_List.size(); i++) {
            Book t = (Book) Book_List.get(i);
            int item = Nums.get(i);
            data.add(new ArrayList<String>() {{
                add(String.valueOf(t.getId()));
                add(t.getName());
                add(String.valueOf(t.getPrice()));
                add(String.valueOf(item));
            }});
        }
        new Main_program(data).println(8);
    }

    public static boolean Execute(String UserName, int Choice, User user) {
        Scanner scanner = new Scanner(System.in);
        if (UserName.equals("Admin")) {
            switch (Choice) {
                case 1: {
                    System.out.println("请输入要入库的书的编号以及数量(用空格分开)");
                    user.In(scanner.nextInt(), scanner.nextInt());
                    return true;
                }
                case 2: {
                    System.out.println("请输入要出库的书的编号以及数量(用空格分开)");
                    user.Out(scanner.nextInt(), scanner.nextInt());
                    return true;
                }
                case 3: {
                    System.out.println("请输入要新增图书的名字，作者，出版日期，价格，库存量(用空格分开)");
                    Book book = new Book();
                    int id = 10005;
                    List bookList = user.query();
                    for (int i = 0; i < bookList.size(); i++) {
                        Book t = (Book) bookList.get(i);
                        id = t.getId();
                    }
                    user.Save(book, id + 1, scanner.next(), scanner.next(), scanner.next(), scanner.nextInt(), scanner.nextInt());
                    return true;
                }
                case 4: {
                    System.out.println("已拥有的所有图书如下：");
                    ShowAllBooks(user.query());
                    return true;
                }
                case 0: {
                    System.out.println("管理员已登出！");
                    user.Sign_out();
                    return false;
                }
                default:
                    return false;
            }

        } else {
            switch (Choice) {
                case 1: {
                    System.out.println("可购买的所有图书如下：");
                    ShowAllBooks(user.query());
                    return true;
                }
                case 2: {
                    System.out.println("请输入购买的图书编号以及数量(用空格分开)");
                    int id = scanner.nextInt();
                    int num = scanner.nextInt();
                    Buy_List.add(user.getById(id));
                    Buy_Num.add(num);
                    return true;
                }
                case 3: {
                    System.out.println("附赠品信息如下：");
                    List Names = user.getEXInfo();
                    for (int i = 0, j = 1; i < Names.size(); i++, j++) {
                        String name = (String) Names.get(i);
                        System.out.println(j + ".  " + name);
                    }
                    return true;
                }
                case 4: {
                    System.out.println("请输入要购买的附赠品编号！(1-3)");
                    int item = scanner.nextInt();
                    if (item >= 1 && item <= 3) {
                        System.out.println("请支付" + user.BuyEx(item).getPrice() + "元");
                    }
                    else
                        System.out.println("编号错误，请重新输入！");
                    return true;
                }
                case 5: {
                    System.out.println("您要购买的书目如下所示：");
                    ShowBuyBooks(Buy_List, Buy_Num);
                    System.out.println("请支付" + user.Checkout(Buy_List, Buy_Num) + "元");
                    System.out.println("是否购买(Y/N)");
                    if(scanner.next().equals("Y")){
                        for(int i=0;i<Buy_List.size();i++){
                            user.Buy(Buy_List.get(i).getId(),Buy_Num.get(i));
                        }
                        System.out.println("购买成功！");
                    }
                    return true;
                }
                case 0: {
                    user.Sign_out();
                    return false;
                }
                default:
                    return false;
            }
        }
    }

    public void println(Integer interval) {
        Integer width = data.get(0).size();
        Integer high = data.size();
        Integer[] maxWidths = getMaxWidth();
        for (int i = 0; i < high; i++) {
            for (int y = 0; y < width; y++) {
                String text = data.get(i).get(y);
                Integer maxWidth = maxWidths[y];
                if (y > 0) {
                    maxWidth += interval;
                }
                System.out.print(getPlace(text, maxWidth));
            }
            System.out.println();
        }
    }

    public String getPlace(String text, Integer maxWidth) {
        int textSize = text.length();
        for (int i = 0; i < maxWidth - textSize; i++) {
            text = " " + text;
        }
        return text;
    }

    /**
     * 计算每一列每行内容的最大长度
     */
    public Integer[] getMaxWidth() {
        Integer width = data.get(0).size();
        Integer high = data.size();
        Integer[] widthArray = new Integer[width];
        for (int w = 0; w < width; w++) {
            String[] array = new String[high];
            for (int h = 0; h < high; h++) {
                array[h] = data.get(h).get(w);
            }
            widthArray[w] = getLengthMax(array);
        }
        return widthArray;
    }

    /**
     * 获取数组字符串中长度最大的值
     */
    public Integer getLengthMax(String[] arr) {
        Integer max = arr[0].length();
        for (int i = 1; i < arr.length; i++) {
            if (arr[i].length() > max) {
                max = arr[i].length();
            }
        }
        return max;
    }

    public Main_program(List<List<String>> data) {
        this.data = data;
    }

    public List<List<String>> getData() {
        return data;
    }

    public void setData(List<List<String>> data) {
        this.data = data;
    }

}
