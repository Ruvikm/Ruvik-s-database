package FlowerStore.Forms;/*
 * Created by JFormDesigner on Wed May 06 18:33:22 CST 2020
 */

import FlowerStore.Factory.FactoryService;
import FlowerStore.Realize.Service.ICustomerService;
import FlowerStore.Realize.Service.IFlowerStoreService;

import javax.swing.UIManager;
import javax.swing.JOptionPane;//导入java.swing包下的JOptionPane类
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;


/**
 * @author Ruvik
 */
public class login extends JFrame {
    public static String name = "";
    public String password = "";
    private String select="";
    // JFormDesigner - Variables declaration - DO NOT MODIFY  //GEN-BEGIN:variables
    private JLabel Login_user;
    private JLabel Login_password;
    private JTextField username_test;
    private JPasswordField password_test;
    private JButton Login_button;
    private JRadioButton user_check;
    private JRadioButton manager_check;
    private JLabel registered;
    private JLabel Login_title;
    // JFormDesigner - End of variables declaration  //GEN-END:variables

    public login(){
        initComponents();
    }

    //登录
    private void Login_buttonActionPerformed(ActionEvent e) {
        // TODO add your code here
        name = username_test.getText();
        password = String.valueOf(password_test.getPassword());
        //System.out.println(name+"  "+password);
        IFlowerStoreService iFlowerStoreService = FactoryService.getFlowerStoreService();
        ICustomerService iCustomerService = FactoryService.getiCustomerService();
        if (!name.equals("") && !password.equals("")) {
            if (select.equals("管理员")) {
                if (iFlowerStoreService.Login(name, password)) {
                    JOptionPane.showMessageDialog(null, "欢迎登录，管理员！");
                    new Manager_Home().setVisible(true);
                    this.dispose();
                } else
                    JOptionPane.showMessageDialog(null, "用户名或密码输入错误！");
            } else if (select.equals("用户")) {
                if (iCustomerService.C_Login(name, password)) {
                    JOptionPane.showMessageDialog(null, "欢迎登录，" + name + "！");
                    new Customer_Home().setVisible(true);
                    this.dispose();
                } else
                    JOptionPane.showMessageDialog(null, "用户名或密码输入错误！");
            } else
                JOptionPane.showMessageDialog(null, "请选择用户类型！");
        } else
            JOptionPane.showMessageDialog(null, "请输入用户名和密码！");

    }

    //region 获取JRadioButtton中的选项

    private void manager_checkActionPerformed(ActionEvent e) {
        // TODO add your code here
        JRadioButton sourceButton=(JRadioButton)e.getSource();
        select=sourceButton.getText();

    }

    private void user_checkActionPerformed(ActionEvent e) {
        // TODO add your code here
        JRadioButton sourceButton=(JRadioButton)e.getSource();
        select=sourceButton.getText();
    }

    //endregion

    //弹出注册页面
    private void registeredMouseClicked(MouseEvent e) {
        // TODO add your code here
        new regist().setVisible(true);
    }

    private void initComponents() {
        // JFormDesigner - Component initialization - DO NOT MODIFY  //GEN-BEGIN:initComponents
        Login_user = new JLabel();
        Login_password = new JLabel();
        username_test = new JTextField();
        password_test = new JPasswordField();
        Login_button = new JButton();
        user_check = new JRadioButton();
        manager_check = new JRadioButton();
        registered = new JLabel();
        Login_title = new JLabel();

        //======== this ========
        setMinimumSize(new Dimension(360, 430));
        setTitle("\u767b\u5f55");
        setMaximizedBounds(new Rectangle(100, 100, 360, 430));
        Container contentPane = getContentPane();
        contentPane.setLayout(null);

        //---- Login_user ----
        Login_user.setText("\u7528\u6237\u540d");
        Login_user.setFont(Login_user.getFont().deriveFont(Login_user.getFont().getSize() + 4f));
        contentPane.add(Login_user);
        Login_user.setBounds(90, 155, 65, Login_user.getPreferredSize().height);

        //---- Login_password ----
        Login_password.setText("\u5bc6\u7801");
        Login_password.setFont(Login_password.getFont().deriveFont(Login_password.getFont().getSize() + 4f));
        contentPane.add(Login_password);
        Login_password.setBounds(90, 280, 60, Login_password.getPreferredSize().height);
        contentPane.add(username_test);
        username_test.setBounds(90, 190, 220, 28);
        contentPane.add(password_test);
        password_test.setBounds(90, 320, 220, 28);

        //---- Login_button ----
        Login_button.setText("\u767b\u5f55");
        Login_button.setFont(Login_button.getFont().deriveFont(Login_button.getFont().getSize() + 2f));
        Login_button.addActionListener(e -> Login_buttonActionPerformed(e));
        contentPane.add(Login_button);
        Login_button.setBounds(140, 440, 120, Login_button.getPreferredSize().height);

        //---- user_check ----
        user_check.setText("\u7528\u6237");
        user_check.setFont(user_check.getFont().deriveFont(user_check.getFont().getSize() + 4f));
        user_check.addActionListener(e -> user_checkActionPerformed(e));
        contentPane.add(user_check);
        user_check.setBounds(new Rectangle(new Point(225, 390), user_check.getPreferredSize()));

        //---- manager_check ----
        manager_check.setText("\u7ba1\u7406\u5458");
        manager_check.setFont(manager_check.getFont().deriveFont(manager_check.getFont().getSize() + 4f));
        manager_check.addActionListener(e -> manager_checkActionPerformed(e));
        contentPane.add(manager_check);
        manager_check.setBounds(new Rectangle(new Point(280, 390), manager_check.getPreferredSize()));

        //---- registered ----
        registered.setText("\u6ce8\u518c\u8d26\u6237");
        registered.setCursor(Cursor.getPredefinedCursor(Cursor.HAND_CURSOR));
        registered.setFont(registered.getFont().deriveFont(registered.getFont().getSize() + 4f));
        registered.addMouseListener(new MouseAdapter() {
            @Override
            public void mouseClicked(MouseEvent e) {
                registeredMouseClicked(e);
            }
        });
        contentPane.add(registered);
        registered.setBounds(30, 470, 65, registered.getPreferredSize().height);

        //---- Login_title ----
        Login_title.setText("WELCOME");
        Login_title.setFont(Login_title.getFont().deriveFont(Login_title.getFont().getSize() + 6f));
        contentPane.add(Login_title);
        Login_title.setBounds(153, 50, 94, 30);

        contentPane.setPreferredSize(new Dimension(400, 560));
        setSize(400, 560);
        setLocationRelativeTo(null);

        //---- buttonGroup1 ----
        ButtonGroup buttonGroup1 = new ButtonGroup();
        buttonGroup1.add(user_check);
        buttonGroup1.add(manager_check);
        // JFormDesigner - End of component initialization  //GEN-END:initComponents
    }
}
