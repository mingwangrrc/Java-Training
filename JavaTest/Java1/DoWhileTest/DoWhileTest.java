package DoWhileTest;
import java.util.Scanner;

public class DoWhileTest {
    
    public static void main(String[]args){

        int i = 1;
        int count = 0;
        int sum = 0;

        do{
            if(i%2 == 0){
                System.out.println(i);
                count++;
                sum +=i;

            }
            i++;

        }while(i<=100);

        System.out.println(count);
        System.out.println(sum);

    }
}   

class DoWhileTest1
{
    
    public static void main(String[]args)
    {

        double balance = 0.0;
        boolean flag = true;// control loop end

        Scanner sc = new Scanner(System.in);

        do
        {
            System.out.println("==========ATM==========");
            System.out.println("        1. SAVE");
            System.out.println("        2. DEPOSIT");
            System.out.println("        3. BALANCE");
            System.out.println("        4. QUIT");
            System.out.print("PLS CHOOSE(1-4): ");

           
            int selection = sc.nextInt();

            switch(selection)
            {
                case 1:
                    System.out.print("how much money you want to save: ");
                    double money1 = sc.nextDouble();
                    if(money1>0){
                        balance +=money1;
                    }
                    break;

                case 2:
                    System.out.print("how much money you want to deposit: ");
                    double money2 = sc.nextDouble();
                    if(money2>0 && money2<=balance){
                        balance -=money2;
                    }
                    break;

                case 3:
                    System.out.println("your current balance is: "+ balance);
                    break;

                case 4:
                    flag = false;
                    System.out.println("Thank you for using.");
                    break;

                default:
                    System.out.println("Wrong Enter, pls enter again");
            }

        }while(flag);
        sc.close();

    }
}