package 实验二图书销售系统.物品;

import java.util.ArrayList;
import java.util.List;

public class EXFactory {

    private static List<String> EXList;
    static {
        EXList=new ArrayList<String>();
        EXList.add(0,"CD");
        EXList.add(1,"Pen");
        EXList.add(2,"Bag");
    }

    public static List<String> getEXList() {
        return EXList;
    }

    public static EX Create(int ID) {
        switch (ID) {

            case 1:
                return new CD();
            case 2:
                return new Pen();
            case 3:
                return new Bag();
            default:
                return null;
        }
    }


}
