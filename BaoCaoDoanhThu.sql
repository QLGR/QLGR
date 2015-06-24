alter procedure BaoCaoDoanhThu
	@Thang int = 1
	  
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT HIEUXE.TenHieuXe,(select count(*) from HOSOSUACHUA where HIEUXE.MaHX=HOSOSUACHUA.MaHX AND MONTH(HOSOSUACHUA.NgayTiepNhan)=@Thang) as SoLuotSua,(select HOSOSUACHUA.TongCong from HOSOSUACHUA where HIEUXE.MaHX=HOSOSUACHUA.MaHX and MONTH(HOSOSUACHUA.NgayTiepNhan)=@Thang) as DoanhSo,(select count(*) from HOSOSUACHUA where HIEUXE.MaHX=HOSOSUACHUA.MaHX AND MONTH(HOSOSUACHUA.NgayTiepNhan)=@Thang)/CAST((select count(*) from HOSOSUACHUA where MONTH(HOSOSUACHUA.NgayTiepNhan)=@Thang) as float) as  TiLe FROM HIEUXE
END
