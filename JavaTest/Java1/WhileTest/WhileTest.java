package WhileTest;
import java.util.Scanner;

public class WhileTest {
    
    public static void main(String[]args){

        int i = 1;
        while(i<=50){
            System.out.println("HelloWorld");
            i++;
        }
    }
}

class WhileTest1{

    public static void main(String[]args){

        int i = 1;
        int sum = 0;
        int count = 0;

        while(i<=100){
            if(i%2==0){
                System.out.println(i);
                count++;
                sum += i;
            }
           
            i++;
        }
        System.out.println("count = "+count);
        System.out.println("sum = "+sum);
    }
}

class WhileTest2{

    public static void main(String[]args){

        int random = (int)(Math.random()*100+1);

        Scanner sc = new Scanner(System.in);


        System.out.print("pls enter a number between 1-100: ");
        int guess = sc.nextInt();
        

        int count = 1;

        while(random != guess){
            if(guess>random){
                System.out.println("smaller");
            }else if(guess<random){
                System.out.println("bigger");
            }

            System.out.print("pls enter a number between 1-100: ");
            guess = sc.nextInt(); 
            count++;
            
        }
            System.out.println("congrats");
            System.out.println("how many times you guess: "+count);
            sc.close();
    }
}

class WhileTest3{

    public static void main(String[]args){

        double paper = 0.1;
        double mountain = 8848860;

        int count = 0;

        while(paper<=mountain){

            paper *=2;
            count++;

        }
        System.out.println("paper = "+(paper/1000)+"m"+", over mountain = "+(mountain/1000));
        System.out.println("count times = "+count);
    }
}
