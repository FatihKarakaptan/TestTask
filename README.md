# TestTask

CreateScript -> MSSQL Server'da tablo oluşturmak için gerekli, identity number, customers tarzında bir tablonun var olması durumunda foreign key olarak geçilebilir ancak, şuan
bu tablo var olmadığı için, ekleme işleminde sorun çıkmaması açısından foreign key olarak tanımlanmamıştır.

Surface tarafı frontend zorunlu olmadığı için çok özenilemedi, çünkü yoğunluktan ancak dün başlayabildim.

Kalan projeler backend tarafı için, dto ve dbo seviyeleri uygulandı. Bütün projelerin contracts isimde, sınıf ve interface tanımlarının yapıldığı class libraryleri mevcut. Gateway
layerda, istek atılıp, sonra 0 ile 1500 arası random int üretilerek, üretilen int response'dan gelmiş gibi davranılmıştır. Swagger UI, ile kolayca test edebilirsiniz.

Proje zaten atomik olduğundan ve tek bir database ihtiyacı olduğundan tek başına bir mikroservis olmalıdır, yani bu proje tek başına daha küçük parçalara bölünemez, ancak ve
ancak mikroservis mimarisine eklenebilecek tek başına bir mikroservis olabilir. Dockerfile linux'a göre generate edilmiştir, Çünkü Linux konteynırları portainer gibi bir çok
tool tarafından desteklenmektedir.
