package RandomTest;

public class RandomTest {
    
    public static void main(String[]args){

        double d1 = Math.random();

        System.out.println("d1: "+ d1);

        //0-100
        int num1 = (int)(Math.random()*101);
        System.out.println("num1: "+num1);

        //1-100
        int num2 = (int)(Math.random()*100)+1;
        System.out.println("num2: "+num2);

        /* a-b
        (int)(Math.random()*(b-a+1))+a;
        */
        
    }
}
