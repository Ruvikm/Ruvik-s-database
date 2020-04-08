package 实验二图书销售系统.接口;

import 实验二图书销售系统.物品.Book;
import 实验二图书销售系统.物品.EX;

import java.util.List;

public interface ICustomer {

     //查询图书
     public List<Book> query();

     //买书
     public Book Buy(int Book_id, int num);

     //获得附赠品信息
     public List<String> getEXInfo();

     //买赠品
     public EX BuyEx(int ExCode);

     //结账
     public int CheckOut(List<Book> bookList,List<Integer> Nums);

     //通过书的编码查找书
     public Book getById(int Book_id);
}
