package 实验二图书销售系统.用户;

import 实验二图书销售系统.接口.IAdmin;
import 实验二图书销售系统.物品.Book;
import 实验二图书销售系统.物品.BookList;

import java.util.List;

public class AdminImpl implements IAdmin {

    private BookList Book_List;

    public AdminImpl() {
        Book_List = BookList.getInstance();
    }

    @Override
    public List<Book> query() {
        return Book_List.getAll();
    }

    @Override
    public void In(int Book_id, int num) {
        Book_List.InBook(Book_id, num);
    }

    @Override
    public void Out(int Book_id, int num) {
        Book_List.OutBook(Book_id, num);
    }

    @Override
    public void Save(Book book,int Id, String Name, String Author, String Date, int Price, int Store) {
        Book_List.NewBook(book,Id,Name,Author,Date,Price,Store);
    }
}
