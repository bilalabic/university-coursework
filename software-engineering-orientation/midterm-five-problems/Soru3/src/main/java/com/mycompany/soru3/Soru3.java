
package com.mycompany.soru3;

import java.util.Scanner;
//Kürenin alanının ve hacmini hesaplama 
//Alan=4*π*r^2
//Hacim=4/3*π*r^3


public class Soru3 {
    public static void main(String[] args){
        Scanner scn=new Scanner(System.in);
        
        System.out.print("Yaricapi giriniz: ");
        double yariCap=scn.nextDouble();
        
        final double PI=3.14;
        
        double alan=4*PI*yariCap*yariCap;
        double hacim=(PI*yariCap*yariCap*yariCap*4)/3;
        System.out.println("Alan= "+alan);
        System.out.println("Hacim= "+hacim);
    }
    
}
