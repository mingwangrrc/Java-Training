package ForForTest;

public class ForForTest {
    
    public static void main(String[]args)
    {
        for(int j =1; j<=5; j++)
        {
            for(int i =1; i <=6; i++)
            {
            System.out.print("*");
            }
        System.out.println();
        }

        System.out.println();
        System.out.println();

        for(int i=1; i<=5; i++)
        {
            
            for(int j = 1; j<=i; j++)
            {
                System.out.print("*");
            }
            System.out.println();
        }

        for(int i=1; i<=6; i++)
        {

            for(int j=1; j<=7-i; j++)
            {
                System.out.print("*");
            }
            System.out.println();
        }
    }
}

class ForForTest1{

    public static void main(String[]args){

        for(int i = 1; i <=5; i++){
            for(int j = 1;j<=10-2*i; j++){
                System.out.print(" ");
            }
            for(int x = 1; x<=2*i-1;x++){
                System.out.print(" *");
            }
            System.out.println();
        }
        for(int i =1;i<=5;i++){
            for(int j =1;j<=2*i;j++ ){
                System.out.print(" ");
            }
            for(int x=1;x<=9-2*i; x++){
                System.out.print(" *");
            }
            System.out.println();
        }
    }
}

class ForForTest2{

    public static void main(String[]args){

        for(int i =1;i<=9;i++){
            for(int j =1;j<=i;j++){

                System.out.print(i+"*"+j+"= "+(i*j)+"\t");
            }
            System.out.println();
        }
    }
}