package ScannerTest;
import java.util.Scanner;

public class ScannerTest {
    
    public static void main(String[]atgs)
    {

        Scanner sc = new Scanner(System.in);

        System.out.printf("pls enter your name: ");
        String name = sc.next();

        System.out.printf("enter your age: ");
        int age = sc.nextInt();

        System.out.printf("enter your weight: ");
        double weight = sc.nextDouble();

        System.out.printf("enter your gender(male\\female): ");
        char gender = sc.next().charAt(0);
        
        System.out.printf("have you married(true for yes, false for no): ");
        boolean maritalStatus = sc.nextBoolean();
        
        System.out.println("your name: "+name+", age: "+age+", weight: "+weight+", gender: "+gender+", Marital Status: "+maritalStatus);

        sc.close();
    }
}
class ScannerTest2{
    public static void main(String[]args){

        Scanner sc = new Scanner(System.in);
        System.out.println("CHECK YOUR POSITION");

        System.out.printf("Enter your hight: ");
        double hight = sc.nextDouble();

        System.out.printf("Enter your wealth(money you have): ");
        double wealth = sc.nextDouble();
        
        System.out.printf("Are your handsome?(True for yes, False for no): ");
        Boolean isHandsome = sc.nextBoolean();

        if(hight>=180 && wealth>=10000000 && isHandsome){
            System.out.println("Marry him!");
        }else if(hight>=180 || wealth>=10000000 || isHandsome){
            System.out.println("still marry him, better than nothing");
        }else{
            System.out.println("Sry, not interested");
        }
     sc.close();
    }
}