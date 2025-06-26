package SwitchCaseTest;
import java.util.Scanner;

public class SwitchCaseTest {
    
    public static void main(String[]args){

        int num = 1;
        switch(num){
            
            case 0:
                System.out.println("zero");
                break;

            case 1:
                System.out.println("one");
                break;//close switch-case

            case 2:
                System.out.println("two");
                break;

            case 3:
                System.out.println("three");
                break;

            default:
                System.out.println("other");
                break;
        }
    }
}
class SwitchCaseTest2{
    
    public static void main(String[]args){
        
        String season = "summer";

        switch(season){

            case "spring":
                System.out.println("spring");
                break;

            case "summer":
                System.out.println("summer");
                break;

            case "autumn":
                System.out.println("autumn");
                break;

            case "winter":
                System.out.println("winter");
                break;

            default:
                System.out.println("wrong season entered");
        }
    }
}
class SwitchCaseTest3
{

    public static void main(String[]args)
    {

        int grades = 110;

        /* method 1:
        switch(grades/10){

            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
                System.out.println("failure");
                break;

            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
                System.out.println("pass");
                break;

            default:
                System.out.println("wrong grades entered");
                break;
                */

        //method 2:
        switch(grades/60)
        {

            case 0:
                System.out.println("failure");
                break;

            case 1:
                System.out.println("pass");
                break;

            default:
                System.out.println("wrong grades entered");
        }   
    }
}
class SwitchCaseTest4{

    public static void main(String[]args)
    {

        Scanner sc = new Scanner(System.in);
        
        System.out.printf("pls enter month: ");
        int months = sc.nextInt();

        System.out.printf("pls enter days: ");
        int days = sc.nextInt();

        sc.close();
        
        int sumDays = 0;


        switch(months)
        {
            case 12:
                sumDays += 30;

            case 11:
                sumDays += 31;

            case 10:
                sumDays += 30;

            case 9:
                sumDays += 31;

            case 8:
                sumDays += 31;

            case 7:
                sumDays += 30;

            case 6:
                sumDays += 31;

            case 5:
                sumDays += 30;

            case 4:
                sumDays += 31;

            case 3:
                sumDays += 28;

            case 2:
                sumDays += 31;

            case 1:
                sumDays += days;
            
            System.out.println("days in total: "+ sumDays);
        }
    }
}

class SwitchCaseTest5{
    /**
     * @param args
     */
    public static void main(String[]args){

        int num1 = (int)(Math.random()*6+1);
        int num2 = (int)(Math.random()*6+1);
        int num3 = (int)(Math.random()*6+1);

        Scanner sc = new Scanner(System.in);

        System.out.printf("enter your choose(tiger,big or small): ");
        String name = sc.next();

        sc.close();

        int a = num1+num2+num3;

        boolean result = false;
        switch(name){

            case "tiger":
                result = num1 ==num2 && num2 == num3;
                break;

            case "big":
                result = a >9;
                break;

            case "small":
                result = a<9;
                break;

        }
        System.out.println("num1,num2,num3 = "+num1+","+num2+","+num3+".");
        System.out.println(result? "right":"wrong");
    }
}