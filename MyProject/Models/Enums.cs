namespace MyProject.Models
{
    // 產權資料
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

    // 不動產說明書
    public enum OwnershipType
    {
        單獨,
        持分共有
    }

    public enum OtherRightsType
    {
        地上權,
        永佃權,
        農育權,
        不動產役權,
        抵押權,
        典權,
        耕作權
    }

    public enum RestrictingRegistrationType
    {
        預告登記,
        查封,
        假扣押,
        假處分,
        其他
    }

    public enum RespectivelyManageBy826Type
    {
        使用管理,
        分割
    }

    public enum DevelopMethodRestrictionsType
    {
        徵收,
        區段徵收,
        市地重劃,
        其他
    }

    public enum BuildFarmhouseType
    {
        不得興建農舍,
        已提供興建農舍
    }

    public enum NationalParkType
    {
        特別景觀區,
        生態保護區,
        史蹟保存區
    }

    public enum DrinkingWaterSourceType
    {
        飲用水水源水質保護區,
        飲用水取水口一定距離內之地區
    }

    public enum PolutedAreaType
    {
        土壤,
        地下水
    }

    public enum TransactionType
    {
        買賣,
        互易
    }

    public enum ChooseManageType
    {
        他項權利,
        限制登記
    }

    public enum SurroundingsAppendiceType
    {
        都市計畫地形圖,
        相關電子地圖
    }

    public enum Surroundings
    {
        都市計畫地形圖,
        相關電子地圖,
        公_f私_b有市場,
        超級市場,
        學校,
        警察局_f分駐所_c派出所_b,
        行政機關,
        體育場,
        醫院,
        飛機場,
        台電變電所用地,
        地面高壓電塔_f線_b,
        寺廟,
        殯儀館,
        公墓,
        火化場,
        骨灰_f骸_b存放設施,
        垃圾場_f掩埋場_c焚化場_b,
        顯見之私人墳墓,
        加油_f氣_b站,
        瓦斯行_f場_b,
        葬儀社
    }
}
