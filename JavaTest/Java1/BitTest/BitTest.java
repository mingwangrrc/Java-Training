package BitTest;

public class BitTest {
    public static void main(String[]args){
        int num1 = 7;
        System.out.println("Test1:");
        System.out.println("num1 << 1: " + (num1 << 1));
        System.out.println("num1 << 2: " + (num1 << 2));
        System.out.println("num1 << 3: " + (num1 << 3));
        System.out.println("num1 << 3: " + (num1 << 29));

        System.out.println();
        System.out.println("Test2:");

        int num2 = -7;
        System.out.println("num2 << 1: " + (num2 << 1));
        System.out.println("num2 << 2: " + (num2 << 2));
        System.out.println("num2 << 3: " + (num2 << 3));
        System.out.println("num2 << 3: " + (num2 << 29));

        //calculate 2*8
        int num3 = 2;
        int num4 = 8;
        System.out.println((num3 << 3));
        System.out.println((num4 << 1));
        
    }
}
class BitExer1{
    public static void main(String[]args){
        //method 1
        int m = 10;
        int n = 20;

        System.out.println("m = "+m+ " n = "+n);

        int temp = m;
        m = n;
        n = temp;
        System.out.println(temp);

        //method 2
        m = m+n;
        n= m-n;
        m= m-n;
        System.out.println(m);
    }
}