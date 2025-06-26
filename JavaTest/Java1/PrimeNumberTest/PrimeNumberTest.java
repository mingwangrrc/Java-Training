package PrimeNumberTest;

public class PrimeNumberTest {
    
    public static void main(String[]args){

        for(int i = 2; i<=100; i++){

            int number = 0;

            for(int j = 2; j<i; j++){

                if(i%j==0){
                number++;
                }
            }
            if(number ==0){
                System.out.println(i);
            }  
        }
    }
}
class BreakContinueTest1{

    public static void main(String[]args){

        for( int i =2; i<=100000 ; i++){

            boolean isFlag = true;

            for(int j =2; j<i ; j++){

                if(i%j == 0){
                    isFlag = false;
                }
            }
            if(isFlag){
                System.out.println(i);
            }
        }
    }
}

class BreakContinueTest2{

    public static void main(String[]args){

        int count = 0;
        long start = System.currentTimeMillis();

        for(int i = 2; i<=100000; i++){

            int number = 0;

            for(int j = 2; j<i; j++)
            {

                if(i%j==0)
                {
                number++;
                }
            }
            if(number ==0)
            {
                count++;
            } 
    }
    long end = System.currentTimeMillis();
    System.out.println("count = "+count);
    System.out.println("time = "+(end-start));
    }
}

class BreakContinueTest3{

    public static void main(String[]args){
      
        int count = 0;
        long start = System.currentTimeMillis();

        for(int i = 2; i<=100000; i++){

            int number = 0;

            for(int j = 2; j<=Math.sqrt(i); j++)
            {

                if(i%j==0)
                {
                number++;
                break;
                }
            }
            if(number ==0)
            {
                count++;
            } 
        }
    long end = System.currentTimeMillis();
    System.out.println("count = "+count);
    System.out.println("time = "+(end-start));
    }
}