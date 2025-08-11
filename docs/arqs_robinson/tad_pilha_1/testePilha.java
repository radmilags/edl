package Pilha.pilha_src;
public class testePilha {

	public static void main(String[] args) {		
		Integer[] b = new Integer[1];		
		PilhaArray pp=new PilhaArray(1,0);
		System.out.println("inserindo elemento");
		for(int f=0;f<10;f++){
		  System.out.println(f);		  
		  pp.push(new Integer(f));
		}
		System.out.println("retirando elemento");
		for(int f=0;f<10;f++){
			  System.out.print(f);
			  System.out.println(" - "+pp.pop());
		}
	}
}
