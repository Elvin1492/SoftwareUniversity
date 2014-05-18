import java.io.BufferedReader;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.Reader;

import javax.sound.sampled.Line;

public class SumNumbersFromATextFile {
	//Write a program to read a text file "Input.txt" holding a sequence of integer numbers, 
	//each at a separate line. Print the sum of the numbers at the console. Ensure you close
	//correctly the file in case of exception or in case of normal execution. 
	//In case of exception (e.g. the file is missing), print "Error" as a result

	public static void main(String[] args) {
		//Create a new fileReader read the lines of the files as string and parse them to int
		//until we reach the last line.CLose the fileReader at the end. Throw and exception Error
		//if the file is missing or the parse was not successful and print the trace
        try{
            BufferedReader reader = new BufferedReader(new FileReader("src/numsToSum.txt"));
            FileWriter writer = new FileWriter("src/copy.txt");
            String line;
            long sum = 0;
            while ((line = reader.readLine()) != null) {
            int number = Integer.parseInt(line);
             sum+=number;
            }
            System.out.println(sum);
            reader.close();
        }catch(Exception exeption){
            System.out.println("Error");
            exeption.printStackTrace();           
        }    
    }
}





