create database DoAn_LTW
use DoAn_LTW

create table TheLoai
(
maloai int identity primary key,
tenloai nvarchar(30)
)
create table ThucAn
(
mathucan int identity(1,1) primary key,
maloai int foreign key (maloai) references TheLoai(maloai) on delete cascade, 
tenthucan nvarchar(100) not null,
mota nvarchar(500),
hinh varchar(50),
giaban decimal(18,0),
soluongton int
)
create table KhachHang(
makh int identity(1,1) primary key,
hoten nvarchar(50),
email varchar(50),
matkhau varchar(10),
diachi nvarchar(100),
dienthoai varchar(15),
loaitv int
)
create table DonHang(
madon int identity(1,1) primary key,
thanhtoan bit,
giaohang bit,
ngaydat date,
ngaygiao date,
makh int foreign key (makh) references KhachHang(makh) on delete cascade, 
)
create table ChiTietDonHang(
madon int foreign key (madon) references DonHang(madon) on delete cascade, 
mathucan int foreign key (mathucan) references ThucAn(mathucan) on delete cascade, 
soluong int,
gia decimal(18,0),
primary key(madon,mathucan)
)



ALTER TABLE DonHang 
ADD diachigiao NVARCHAR (255) NOT NULL;




insert into TheLoai(tenloai) values(N'Heo')
insert into TheLoai(tenloai) values(N'Gà')
insert into TheLoai(tenloai) values(N'Vịt')
insert into TheLoai(tenloai) values(N'Dê')
-- thức ăn heo --
insert into ThucAn(maloai,tenthucan,hinh,mota,giaban,soluongton) values(1,N'Cám Heo Con Cò','/Content/img/camheoconco.png',N'Thức Ăn Siêu Đậm Đặc Cho Heo Thịt Từ 5kg Đến Xuất Chuồng',250000,20)
insert into ThucAn(maloai,tenthucan,hinh,mota,giaban,soluongton) values(1,N'Cám Heo 20kg','/Content/img/camheo20.png',N'Thức Ăn Siêu Đậm Đặc Cho Heo Thịt Từ 20kg Đến Xuất Chuồng',280000,30)
insert into ThucAn(maloai,tenthucan,hinh,mota,giaban,soluongton) values(1,N'Cám Heo 50kg','/Content/img/camheo50.png',N'Thức Ăn Siêu Đậm Đặc Cho Heo Thịt Từ 50kg Đến Xuất Chuồng',390000,25)
insert into ThucAn(maloai,tenthucan,hinh,mota,giaban,soluongton) values(1,N'Cám Heo Mang Thai','/Content/img/camheothai.png',N'Thức Ăn Hỗn Hợp Cho Heo Nái Mang Thai',450000,23)
-- thức ăn gà --
insert into ThucAn(maloai,tenthucan,hinh,mota,giaban,soluongton) values(2,N'Cám Gà Thịt','/Content/img/camgathit.png',N'Thức Ăn Đậm Đặc Cho Gà Thịt Hiệu Con Cò',180000,30)
insert into ThucAn(maloai,tenthucan,hinh,mota,giaban,soluongton) values(2,N'Cám Gà P221','/Content/img/camga1.png',N'Thức Ăn Hỗn Hợp Cho Gà Lông Màu Nuôi Công Nghiệp',210000,20)
insert into ThucAn(maloai,tenthucan,hinh,mota,giaban,soluongton) values(2,N'Cám Gà C225B','/Content/img/camga2.png',N'Thức Ăn Hỗn Hợp Cho Gà Thịt Nuôi Công Nghiệp',240000,25)
insert into ThucAn(maloai,tenthucan,hinh,mota,giaban,soluongton) values(2,N'Cám Gà M823','/Content/img/camga3.png',N'Thức Ăn Hỗn Hợp Cho Gà Thịt Nuôi Công Nghiệp M823',260000,31)

-- thức ăn vịt --
insert into ThucAn(maloai,tenthucan,hinh,mota,giaban,soluongton) values(3,N'Cám Vịt Con','/Content/img/camvit1.png',N'Thức Ăn Hỗn Hợp Cho Vịt Con',140000,25)
insert into ThucAn(maloai,tenthucan,hinh,mota,giaban,soluongton) values(3,N'Cám Vịt C663','/Content/img/camvit2.png',N'Thức Ăn Hỗn Hợp Cho Vịt Thịt',170000,20)
insert into ThucAn(maloai,tenthucan,hinh,mota,giaban,soluongton) values(3,N'Cám Vịt Siêu Trứng','/Content/img/camvit3.png',N'Thức Ăn Hỗn Hợp Cho Vịt Siêu Trứng',230000,27)
insert into ThucAn(maloai,tenthucan,hinh,mota,giaban,soluongton) values(3,N'Cám Vịt Hỗn Hợp','/Content/img/camvit4.png',N'Thức Ăn Hỗn Hợp Cho Vịt Thịt S73',250000,34)

-- thức ăn dê --
insert into ThucAn(maloai,tenthucan,hinh,mota,giaban,soluongton) values(4,N'Cám Dê Hỗn Hợp','/Content/img/camde1.png',N'Thức Ăn Hỗn Hợp Cho Dê Vỗ Béo 5217',210000,21)
insert into ThucAn(maloai,tenthucan,hinh,mota,giaban,soluongton) values(4,N'Cám Dê D1','/Content/img/camde2.png',N'Thức Ăn Hỗn Hợp Cho Dê Vỗ Béo D1',230000,24)
insert into ThucAn(maloai,tenthucan,hinh,mota,giaban,soluongton) values(4,N'Cám Dê D2','/Content/img/camde3.png',N'Thức Ăn Hỗn Hợp Cho Dê Vỗ Béo D2',260000,28)
insert into ThucAn(maloai,tenthucan,hinh,mota,giaban,soluongton) values(4,N'Cám Dê A35-S','/Content/img/camde4.png',N'Thức Ăn Hỗn Hợp Cho Dê Vỗ Béo A35-S',320000,32)

insert into KhachHang(hoten,email,matkhau,diachi,dienthoai,loaitv) values(N'Admin','4thangngoc@gmail.com','123',N'DakLak','0909686868',1)




