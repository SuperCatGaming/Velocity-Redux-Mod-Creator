using System.Collections.Generic;

public class Lists {
    public static List<string> CarList = new List<string>();
    public static List<string> RimList = new List<string>();

    public static void InitializeLists() {
        if (CarList.Count == 0 && DataReference.carData != null) {
            foreach (DataReference.CarData carData in DataReference.carData) {
                CarList.Add(carData.id);
            }
        }
        if (RimList.Count == 0 && DataReference.rimData != null) {
            foreach (DataReference.RimData rimData in DataReference.rimData) {
                RimList.Add(rimData.id);
            }
        }
    }
}
