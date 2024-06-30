# RestfulApi

Bu proje, CQRS (Command Query Responsibility Segregation) Design Pattern, Mediatr ve Redis kullanılarak geliştirilmiş modern bir RESTful API örneğidir. Proje, Docker ile containerize edilmiş ve Docker Compose kullanılarak orchestrate edilmiştir. API'nin tasarımı, GET, POST, DELETE, PATCH ve PUT HTTP methodlarını destekleyen sağlam bir yapı sunmaktadır. Ayrıca, veri doğrulama ve iş mantığı katmanında FluentValidation kullanılmıştır.

Özellikler
CQRS Design Pattern: Komut ve sorguları ayrıştırarak, veri tutarlılığını ve performansı optimize eden bir tasarım deseni uygulanmıştır.
Mediatr: Uygulama bileşenleri arasındaki mesajlaşmayı yönetmek ve CQRS işlemlerini basitleştirmek için kullanılan bir araçtır.
Redis: Veri cache'leme ve state yönetimi için yüksek performanslı, bellek içi bir veri yapısı deposu kullanılmıştır.
Docker & Docker Compose: Uygulama bileşenleri ve bağımlılıkları konteynerler içinde çalıştırılarak, geliştirme ve dağıtım süreçleri kolaylaştırılmıştır.
API Endpointleri
Bu API, çeşitli HTTP methodları ile CRUD işlemlerini gerçekleştiren bir yapı sunar:

GET: Kaynakları listelemek veya belirli bir kaynağı getirmek için kullanılır.
POST: Yeni bir kaynak oluşturmak için kullanılır.
PUT: Mevcut bir kaynağı tamamen güncellemek için kullanılır.
PATCH: Mevcut bir kaynağın bazı alanlarını güncellemek için kullanılır.
DELETE: Bir kaynağı silmek için kullanılır.
Her endpoint, JSON formatında veri alışverişi yapar ve hata yönetimi için standart HTTP durum kodlarını kullanır.

Validasyon
FluentValidation: Girdi verilerini doğrulamak ve veri bütünlüğünü sağlamak için esnek bir doğrulama kütüphanesi kullanılmıştır. Bu sayede, API'ye gönderilen verilerin doğruluğu sağlanmış olur ve hatalar minimize edilir.
ActionFilter: Validasyon işlemlerini actionfilter ile attribute olarak ele alma.

Kullanılan Teknolojiler
.NET Core: API geliştirme için kullanılan platform.
CQRS & Mediatr: Komut ve sorgu işlemlerini ayrıştırmak için kullanılan tasarım deseni ve kütüphane.
Redis: Hızlı veri erişimi ve cache yönetimi için.
Docker: Uygulama konteynerleştirme.
FluentValidation: Veri doğrulama.
