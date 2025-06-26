package JavaTest2;
import java.util.Scanner;

public class Utility{

    private static Scanner scanner = new Scanner(System.in);

    public static char readMenuSelection
    {

        char c;
        for(;;)
        {
            String str = readKeyBoard(1){
            c = str.charAt(0);
            if(c!= '1' && c!='2' && c!='3' && c!='4'){
                System.out.print("wrong enter, enter again: ");
            }
            else
                break;
            }
                return c;
        }
    }

        public static int readNumber()
        {
            int n;
            for(;;){
                String str = readKeyBoard(4);
                try{
                    n =Integer.parseInt(str);
                    break;
                }catch(NumberFormatException e){
                    System.out.print("wrong number, enter again: ");
                }
            }
            return n;
        }

        public static String readString()
        {
            String str = readKeyBoard(8);
            return str;
        }

        public static char readConfirmSelection()
        {
            char c;
            for(;;){
                String str =readKeyBoard(1).toUpperCase();
                c =str.chatAt(0);
                if(c == "Y"|| c == "N"){
                    break;
                }else{
                    System.out.print("wrong choose, enter again: ");
                }
            }   
            return c;
        }

        private static String readKeyBoard(int limit)
        {
            String line = "";
            
            while(scanner.hasNext()){
                line = scanner.nextLine();
                if(line.length()<1 || line.length()>;limit){

                }
            }
        }
        
}

