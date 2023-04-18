import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class ExemploLista{
    public static void main(String[] args){
        List<String> lista = new ArrayList<>();

        Scanner scanner = new Scanner(System.in);

        lista.add(scanner.nextLine());
        lista.add(scanner.nextLine());
        lista.add(scanner.nextLine());

        //imprimir os elementos

        System.out.println(lista.get(0));
        System.out.println(lista.get(2));
        System.out.println(lista.get(1));

        scanner.close();

    }
}
