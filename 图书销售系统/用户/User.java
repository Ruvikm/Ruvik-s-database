package 实验二图书销售系统.用户;
/*
User类为用户和管理员的类型，通过登录名划分权限并且通过角色类的对象Role完成User类的访问操作
在进行对应操作时不用考虑本对象是用户还是管理员所有的权限管理都有
*/

import 实验二图书销售系统.物品.Book;
import 实验二图书销售系统.物品.EX;

import java.util.List;

public class User {

    private Role role = null;
    private String PassWord = "123456";


    /*登录
     * 密码和账号一致，登录成功；账号若为Admin，用户为管理员，否则为顾客
     * 登录同时完成Role中的Description的赋值（管理员/顾客）
     * */

    public boolean Sign_in(String UserName, String PassWord) {
        if (UserName.equals("Admin") && PassWord.equals("123456")) {
            role = new Role("Admin");
            System.out.println("欢迎登录，管理员！");
            return true;
        } else if (UserName.equals("Customer") && PassWord.equals("123456")) {
            role = new Role("Customer");
            System.out.println("欢迎登录，顾客大大！");
            return true;
        }
        System.out.println("还想黑入？怕不是在想peach");
        return false;
    }

    public void Sign_out(){
        role=null;
    }

    public void In(int Book_id, int num) {
        role.In(Book_id, num);
    }

    public void Out(int Book_id, int num) {
        role.Out(Book_id, num);
    }

    public void Save(Book book, int Id, String Name, String Author, String Date, int Price, int Store) {
        role.Save(book,Id,Name,Author,Date,Price,Store);
    }

    public List<Book> query() {
        return role.query();
    }

    public int Checkout(List<Book> bookList,List<Integer> Nums) {
            return role.Checkout(bookList, Nums);
    }

    public Book Buy(int Book_id, int num) {
        return role.Buy(Book_id, num);
    }

    public EX BuyEx(int Excode) {
        return role.BuyEx(Excode);
    }

    public List<String> getEXInfo(){
        return role.getEXInfo();
    }

    public Book getById(int Book_id){
        return role.getById(Book_id);
    }
}
