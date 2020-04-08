package 实验二图书销售系统.接口;

import 实验二图书销售系统.物品.Book;

import java.util.List;
public interface IAdmin {

    //入库
    public void In(int Book_id, int num);

    //出库
    public void Out(int Book_id, int num);

    //新增图书
    public void Save(Book book, int Id, String Name, String Author, String Date, int Price, int Store);

    //查询图书
    public List<Book> query();
}
