package IfElseTest;

public class IfElseTest {
    
    public static void main(String[]args)
    {

        int heartBeats = 110;

        if(heartBeats>=60 &&heartBeats<=100 )
        {
            System.out.println("you need test");
        }else{
            System.out.println("you good");
        }
    }
}
class IfElseTest2{
    public static void main(String[]args){
        int num = 10;

        if(num%2 == 0){
            System.out.println("even");   
        }else{
            System.out.println("odd");
        }
    }
}
class IfElseTest3{
    public static void main(String[]args){
        int grades = 59;

        if(grades == 100){
            System.out.println("sportscar");
        }else if(grades>80 &&grades<100){
            System.out.println("bicycle");
        }else if(grades >=60 && grades<=80){
            System.out.println("amusement park");
        }else{
            System.out.println("Gone");
        }
    }
}
class IfElseTest4 {
    public static void main(String[] args) {

        int num1 = 1;
        int num2 = 2;
        int num3 = 3;

        if (num1 > num2 && num1 > num3 && num2 > num3) {
            System.out.println(num1 + "," + num2 + "," + num3);
        } else if (num2 > num1 && num2 > num3 && num3 > num1) {
            System.out.println(num2 + "," + num3 + "," + num1);
        } else {
            System.out.println(num3 + "," + num2 + "," + num1);
        }
    }
}

