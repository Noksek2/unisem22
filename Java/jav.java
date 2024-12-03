import java.util.*;
public class jav{
	public static void main(String args[]){
		new TextRead().start();
		new TextRead().start();
	}
}
class TextRead extends Thread{
	String text;
	public TextRead(){
		text="나는 바나나를 먹는 원숭이";
	}
	@Override
	public void run(){
		Random rnd=new Random();
		for(int i=0;i<text.length();i++){
		System.out.print(text.charAt(i));
		try{
			Thread.sleep(rnd.nextInt(1000));
		}
		catch(InterruptedException e){

		}
	}
	}
}