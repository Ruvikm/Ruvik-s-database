package 实验二图书销售系统.物品;

public class EX {
    private int price;
    private String ex_name;

    public int getPrice() {
        return price;
    }

    public void setPrice(int price) {
        this.price = price;
    }

    public String getEx_name() {
        return ex_name;
    }

    public void setEx_name(String ex_name) {
        this.ex_name = ex_name;
    }
}

class Bag extends EX{
    public Bag() {
        this.setEx_name("Bag");
        this.setPrice(50);
    }
}

class CD extends EX{
    public CD() {
        this.setEx_name("CD");
        this.setPrice(27);
    }
}

class Pen extends EX{
    public Pen() {
        this.setEx_name("Pen");
        this.setPrice(10);
    }

}