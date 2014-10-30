/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package helloworldapp;

/**
 *
 * @author Svetoslav
 */
public class Bicycle {
    int gear;
    int speed;
    int cadance;
    
    void changeGear(int gearValue){
        gear = gearValue;
    }
    
    void chanceSpeed(int speedValue){
        speed = speedValue;
    }
    
    void changeCadance(int cadanceValue){
        cadance = cadanceValue;
    }
}
