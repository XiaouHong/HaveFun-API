using HaveFun_API.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HaveFun_API.Models.PO;

/// <summary>
/// 成員
/// </summary>
public class MemberPO
{
    /// <summary>
    /// 編號
    /// </summary>
    [Key]
    public int ID { get; set; } = 0;

	/// <summary>
	/// RefreshToken
	/// </summary>
	[MaxLength(500)]
	public string RefreshToken { get; set; } = "";

	/// <summary>
	/// Token
	/// </summary>
	[MaxLength(500)]
	public string Token { get; set; } = "";

	/// <summary>
	/// 郵箱
	/// </summary>
	[MaxLength(100)]
	public string Mail { get; set; } = "";

    /// <summary>
    /// 名字
    /// </summary>
    [MaxLength(20)]
    public string Name { get; set; } = "";

    /// <summary>
    /// 暱稱
    /// </summary>
    [MaxLength(20)]
    public string NickName { get; set; } = "";

	/// <summary>
	/// 自我介紹
	/// </summary>
	public string Note { get; set; } = "";

    /// <summary>
    /// 權限類別
    /// </summary>
    public AuthorityType AuthorityType { get; set; } = AuthorityType.Normal;
}
