package 实验二图书销售系统.用户;

import 实验二图书销售系统.接口.ICustomer;
import 实验二图书销售系统.物品.Book;
import 实验二图书销售系统.物品.BookList;
import 实验二图书销售系统.物品.EX;

import java.util.List;

public class CustomerImpl implements ICustomer {

    private BookList Book_List;

    public CustomerImpl() {
        Book_List = BookList.getInstance();
    }

    @Override
    public Book Buy(int Book_id, int num) {
        return Book_List.BuyBook(Book_id, num);
    }

    @Override
    public EX BuyEx(int ExCode) {
        return Book_List.BuyEx(ExCode);
    }

    @Override
    public int CheckOut(List<Book> bookList,List<Integer> Nums) {
        return Book_List.CheckOut(bookList, Nums);
    }

    @Override
    public List<Book> query() {
        return Book_List.getAll();
    }

    @Override
    public List<String> getEXInfo() {
        return Book_List.getExNames();
    }

    @Override
    public Book getById(int Book_id) {
        return Book_List.getById(Book_id);
    }
}