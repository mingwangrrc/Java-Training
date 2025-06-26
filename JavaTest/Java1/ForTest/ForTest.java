package ForTest;
import java.util.Scanner;

public class ForTest {
    
    public static void main(String[]args){

        for(int i = 1 ; i <=100;i++ ){
            System.out.println("HelloWorld");
        }
    }
}

class ForTest1{

    public static void main(String[]args){
        int num = 1;

        for(System.out.print("a");num<3;System.out.print("c"),num++){
            System.out.print("b");
        }
    }
}

class ForTest2{
    public static void main(String[]args){
        
        int count = 0;
        int sum = 0;

        for(int i = 1; i<=100; i++){
            if(i%2 == 0)
            {
                System.out.println(i);
                count++;
                sum+=i;
            }
        }
        System.out.println(count);
        System.out.println(sum);
    }
}
class ForTest3{

    public static void main(String[]args){

        for(int i = 100;i<= 999;i++){

            int num = i%10;
            int num10 = i/10%10;
            int num100 = i/100;

            if(i == num*num*num+num10*num10*num10+num100*num100*num100){
                System.out.println(i);
            }
        }       
    }
}

class ForTest4{

    public static void main(String[]args){

        Scanner sc = new Scanner(System.in);

        System.out.printf("enter num1 = ");
        int num1 = sc.nextInt();

        System.out.printf("enter num2 = ");
        int num2 = sc.nextInt();

        sc.close();

        int min = (num1<num2)? num1:num2;

        //i = Max Common Divisor
        for(int i = min; i>=1; i--){
            if(num1%i == 0 && num2%i ==0){
                System.out.println("Max Common Divisor = "+i);
                break;
            }
        }
        /*
        int result = 1;
        
        i = Max Common Divisor

        for(int i = 1;i<=min;i++){
            if(num1%i == 0 && num2%i == 0){
               result = i;
            }
        }
        System.out.println(result);
        */

        int max = (num1>num2)? num1:num2;

        //i = Min Common Multiple
        for(int i = max; i<=num1*num2; i++){
            if(i%num1 == 0 && i%num2 == 0){
                System.out.println("Min Common Multiple = "+i);
                break;
            }
        }

    }
}