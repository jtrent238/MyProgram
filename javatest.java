import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
 
public class ArrayInsert {
    public static void main(String[] args) {
        //
        // Creates an array of integer value and prints the original values.
        //
        Integer[] numbers = new Integer[] {1, 2, 3, 8, 13, 21};
        System.out.println("Original numbers: " + Arrays.toString(numbers));
 
        //
        // Creates an ArrayList object and add the entire content of numbers
        // array into the list. We use the add(index, element) method to add
        // element=5 at index=3.
        //
        List<Integer> numberList = new ArrayList<>();
        numberList.addAll(Arrays.asList(numbers));
        numberList.add(3, 5);
 
        //
        // Converts back the list into array object and prints the new values.
        //
        numbers = numberList.toArray(new Integer[numberList.size()]);
        System.out.println("After insert    : " + Arrays.toString(numbers));
    }
}
 