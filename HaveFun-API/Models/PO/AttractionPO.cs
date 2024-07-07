using HaveFun_API.Enum;
using System.ComponentModel.DataAnnotations;

namespace HaveFun_API.Models.PO;

/// <summary>
/// 景點
/// </summary>
public class AttractionPO
{
    /// <summary>
    /// 編號
    /// </summary>
    [Key]
    public int ID { get; set; } = 0;

    /// <summary>
    /// 名字
    /// </summary>
    [MaxLength(50)]
    public string Name { get; set; } = "";

    /// <summary>
    /// 地址編號
    /// </summary>
    public int AddressID { get; set; } = 0;

    /// <summary>
    /// 詳細地址
    /// </summary>
    [MaxLength(50)]
    public string Address { get; set; } = "";

    /// <summary>
    /// 景點類別
    /// </summary>
	public AttractionType Type { get; set; } = AttractionType.Unknow;

    /// <summary>
    /// 創立時間
    /// </summary>
	public DateTime CreateTime { get; set; } = DateTime.MinValue;

    /// <summary>
    /// 創立使用者
    /// </summary>
    public int CreateUser { get; set; } = 0;

    /// <summary>
    /// 更新時間
    /// </summary>
    public DateTime UpdateTime { get; set; } = DateTime.SpecifyKind(new DateTime(1990, 1, 1), DateTimeKind.Utc);

    /// <summary>
    /// 更新使用者
    /// </summary>
    public int UpdateUser { get; set; } = 0;
}
