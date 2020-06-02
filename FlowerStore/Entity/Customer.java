package FlowerStore.Entity;

public class Customer {
    private int customer_id; //顾客ID
    private String customer_name;//顾客名字
    private String customer_sex;//顾客性别
    private String customer_sign;//个性签名
    private String customer_phone;//电话

    public int getCustomer_id() {
        return customer_id;
    }

    public void setCustomer_id(int customer_id) {
        this.customer_id = customer_id;
    }

    public String getCustomer_name() {
        return customer_name;
    }

    public void setCustomer_name(String customer_name) {
        this.customer_name = customer_name;
    }

    public String getCustomer_sex() {
        return customer_sex;
    }

    public void setCustomer_sex(String customer_sex) {
        this.customer_sex = customer_sex;
    }

    public String getCustomer_sign() {
        return customer_sign;
    }

    public void setCustomer_sign(String customer_sign) {
        this.customer_sign = customer_sign;
    }

    public String getCustomer_phone() {
        return customer_phone;
    }

    public void setCustomer_phone(String customer_phone) {
        this.customer_phone = customer_phone;
    }
}
