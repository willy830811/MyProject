namespace MyProject.Models
{
    public enum PropertyType
    {
        公寓,
        華廈,
        電梯大樓,
        透天厝,
        別墅,
        廠房,
        土地,
        住家,
        辦公,
        店面,
        車位,
        其他
    }

    public enum Use
    {
        住家用,
        商業用,
        住商用,
        其他
    }
    public enum Status
    {
        預售,
        空屋,
        自住,
        出租
    }

    public enum MainMaterial
    {
        加強磚造,
        鋼筋混凝土,
        鋼骨混凝土,
        其他
    }

    public enum OutsideMaterial
    {
        口磚,
        二丁掛,
        石材,
        玻璃帷幕牆,
        金屬帷幕牆,
        馬賽克,
        水泥,
        方塊磚,
        磨石子,
        其他
    }

    public enum ParkingEntrance
    {
        坡道,
        升降,
        平面
    }

    public enum ParkingType
    {
        平面,
        機械
    }

    public enum BringingType
    {
        洽管理員,
        洽專員,
        沒鎖,
        鑰匙
    }
}
