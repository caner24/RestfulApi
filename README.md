# RestfulApi

Bu proje, CQRS (Command Query Responsibility Segregation) Design Pattern, Mediatr ve Redis kullanılarak geliştirilmiş modern bir RESTful API örneğidir. Proje, Docker ile containerize edilmiş ve Docker Compose kullanılarak orchestrate edilmiştir. API'nin tasarımı, GET, POST, DELETE, PATCH ve PUT HTTP methodlarını destekleyen sağlam bir yapı sunmaktadır. Ayrıca, veri doğrulama ve iş mantığı katmanında FluentValidation kullanılmıştır.

Özellikler
<br>
CQRS Design Pattern: Komut ve sorguları ayrıştırarak, veri tutarlılığını ve performansı optimize eden bir tasarım deseni uygulanmıştır.
<br>
Mediatr: Uygulama bileşenleri arasındaki mesajlaşmayı yönetmek ve CQRS işlemlerini basitleştirmek için kullanılan bir araçtır.
<br>
Redis: Veri cache'leme ve state yönetimi için yüksek performanslı, bellek içi bir veri yapısı deposu kullanılmıştır.
<br>
Docker & Docker Compose: Uygulama bileşenleri ve bağımlılıkları konteynerler içinde çalıştırılarak, geliştirme ve dağıtım süreçleri kolaylaştırılmıştır.
<br>

API Endpointleri
Bu API, çeşitli HTTP methodları ile CRUD işlemlerini gerçekleştiren bir yapı sunar:
<br>

GET: Kaynakları listelemek veya belirli bir kaynağı getirmek için kullanılır.
<br>
POST: Yeni bir kaynak oluşturmak için kullanılır.
<br>
PUT: Mevcut bir kaynağı tamamen güncellemek için kullanılır.
<br>
PATCH: Mevcut bir kaynağın bazı alanlarını güncellemek için kullanılır.
<br>
DELETE: Bir kaynağı silmek için kullanılır.
<br>
Her endpoint, JSON formatında veri alışverişi yapar ve hata yönetimi için standart HTTP durum kodlarını kullanır.
<br>

Validasyon
FluentValidation: Girdi verilerini doğrulamak ve veri bütünlüğünü sağlamak için esnek bir doğrulama kütüphanesi kullanılmıştır. Bu sayede, API'ye gönderilen verilerin doğruluğu sağlanmış olur ve hatalar minimize edilir.
<br>
ActionFilter: Validasyon işlemlerini actionfilter ile attribute olarak ele alma.
<br>

Kullanılan Teknolojiler
<br>
.NET Core: API geliştirme için kullanılan platform.
<br>
CQRS & Mediatr: Komut ve sorgu işlemlerini ayrıştırmak için kullanılan tasarım deseni ve kütüphane.
<br>
Redis: Hızlı veri erişimi ve cache yönetimi için.
<br>
Docker: Uygulama konteynerleştirme.
<br>
FluentValidation: Veri doğrulama.
<br>
