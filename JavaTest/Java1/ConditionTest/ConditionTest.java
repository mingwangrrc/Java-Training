package ConditionTest;

public class ConditionTest {
    
    public static void main(String[]args){

        String info = (2<1)? "Yes":"NO";
        System.out.println(info);

        double result = (2>1)? 1:2.0;
        System.out.println(result);

        //Test1:get the greater number between two input numbers."
        int m = 1;
        int n = 2;
        int max = (m>n)? m:n;
        System.out.println(max);

        //Test2:get the max number among three numbers.
        int i = 20;
        int j = 30;
        int k = 25;
        int tempMax = (i>j)? i:j;
        int finalMax = (tempMax>k)? tempMax:k;
        System.out.println(finalMax);
    }
}
//Today is Tuesday. 10 days later, what day will it be?
class ConditionExer {
    public static void main(String[]args){

        int week = 2;

        week += 10;

        week %= 7;
        System.out.println(week);


    }
}