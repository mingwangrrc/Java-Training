package ForWhileTest;
import java.util.Scanner;

public class ForWhileTest {
    
    public static void main(String[]args){

        while(true){
            System.out.println("1");
        }
    }
}

class ForWhileTest1{

    public static void main(String[]args){

        for(;;){
            System.out.println("1");
        }
    }
}

class ForWhileTest2{

    public static void main(String[]args){

        Scanner sc = new Scanner(System.in);

        int positiveCount = 0;
        int negativeCount = 0;

        while(true)
        {
        System.out.print("pls enter a number(0 will end the program): ");
        double number = sc.nextDouble();

        if(number>0)
        {
            positiveCount++;
        }else if(number<0){
            negativeCount++;
        }else{
            System.out.println("program end");
            break;
        }
        }
        System.out.println("positive = "+positiveCount);
        System.out.println("negative = "+negativeCount);
        sc.close();
    }
}