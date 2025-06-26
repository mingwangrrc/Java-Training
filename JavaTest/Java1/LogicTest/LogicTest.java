package LogicTest;

public class LogicTest {
    public static void main(String[]args){

        boolean a1 = false;
        int a2 = 10;

        if(a1&(a2++>=0)){
            System.out.println(1);
        }else{
            System.out.println(2);
        }
        System.out.println(a2);


        boolean b1 = false;
        int b2 = 10;

        if(b1&&(b2++>=0)){
            System.out.println(1);
        }else{
            System.out.println(2);
        }
        System.out.println(b2);
    }
}
class LogicTest2{
    public static void main(String[]args){

        int c1 = 1;
        boolean c2 = true;

        if(c2||(c1>=1)){
            System.out.println(1);
        }else{
            System.out.println(2);
        }

        int d1 = 1;
        boolean d2 = false;

        if(d2||(d1++<1)){
            System.out.println(1);
        }else{
            System.out.println(2);
        }
    }
}
class LogicExer{
    public static void main(String[]args){

        int e1,e2;
        e1 = e2 = 20;

        boolean bo1 = (++e1 % 3 == 0)&&(e1++ % 7 == 0);
        System.out.println(bo1);

        boolean bo2 = (e2++ % 3 == 0)&&(++e2 % 7 == 0);
        System.out.println(bo2);

    }
}