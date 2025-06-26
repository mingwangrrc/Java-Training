package StringTest;
public class StringTest 
{
    public static void main(String[]args){
        String name = "Ming Wang";
        System.out.println(name);
        boolean isMarried = false;
        if (isMarried)
        {
            System.out.println("Congrats.");
        }else{
            System.out.println("1");
        }
    }

}
class StringExer{
    public static void main(String[]args){
        String name = "Ming Wang";

        int age = 21;

        String gender = "Male";

        double hight = 170;

        String PhoneNumber = "4168249257";

        boolean isMarried = false;

        if(isMarried)
        {
            System.out.println("None");
        }else{
            System.out.println("Name:"+name + " ,Age:"+age + " ,Gender:"+gender + 
                               " ,Hight:"+hight+ " ,PhoneNumber:"+ PhoneNumber + 
                               " ,Marry Status:"+isMarried);
        }

    }
}

