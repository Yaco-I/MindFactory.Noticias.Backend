using MindFactory.Noticias.Backend.Infrastructure.Entities;

namespace MindFactory.Noticias.Backend.Infrastructure.Seed;

public static class SeedData
{
    public static void Initialize(NoticiasDbContext context)
    {
        if (!context.Categorias.Any())
        {
            context.Categorias.AddRange(
    new Categoria
    {
        Nombre = "Empresa",
        Slug = "empresa",
        Descripcion = null,
        CreatedDate = DateTime.UtcNow,
        CreatedBy = 1,
        LastModifiedDate = DateTime.UtcNow,
        LastModifiedBy = 1
    },
    new Categoria
    {
        Nombre = "Productos",
        Slug = "productos",
        Descripcion = null,
        CreatedDate = DateTime.UtcNow,
        CreatedBy = 1,
        LastModifiedDate = DateTime.UtcNow,
        LastModifiedBy = 1
    },
    new Categoria
    {
        Nombre = "Tecnología",
        Slug = "tecnologia",
        Descripcion = null,
        CreatedDate = DateTime.UtcNow,
        CreatedBy = 1,
        LastModifiedDate = DateTime.UtcNow,
        LastModifiedBy = 1
    },
    new Categoria
    {
        Nombre = "Éxitos",
        Slug = "exitos",
        Descripcion = null,
        CreatedDate = DateTime.UtcNow,
        CreatedBy = 1,
        LastModifiedDate = DateTime.UtcNow,
        LastModifiedBy = 1
    },
    new Categoria
    {
        Nombre = "Eventos",
        Slug = "eventos",
        Descripcion = null,
        CreatedDate = DateTime.UtcNow,
        CreatedBy = 1,
        LastModifiedDate = DateTime.UtcNow,
        LastModifiedBy = 1
    },
    new Categoria
    {
        Nombre = "Carreras",
        Slug = "carreras",
        Descripcion = null,
        CreatedDate = DateTime.UtcNow,
        CreatedBy = 1,
        LastModifiedDate = DateTime.UtcNow,
        LastModifiedBy = 1
    },
    new Categoria
    {
        Nombre = "Alianzas",
        Slug = "alianzas",
        Descripcion = null,
        CreatedDate = DateTime.UtcNow,
        CreatedBy = 1,
        LastModifiedDate = DateTime.UtcNow,
        LastModifiedBy = 1
    }
);

            context.SaveChanges();
        }

        if (!context.Noticias.Any())
        {

            context.Noticias.AddRange(
             new Noticia
             {
                 Titulo = "Gestión con propósito compartido",
                 Resumen = "La gestión no es solo números: es personas alineadas en un mismo propósito.",
                 Contenido = @"La gestión no se trata solo de números y presentaciones: se trata de personas alineando un propósito común.

Por eso nos juntamos como corresponde: en la misma mesa, compartiendo ideas… y también un buen asado.

Porque cuando el equipo conecta, las metas dejan de ser objetivos aislados y se convierten en logros compartidos.",
                 URL = "https://instagram.fcor18-1.fna.fbcdn.net/v/t51.2885-15/536758560_17883959376358972_8437501190767175037_n.jpg?stp=dst-jpg_e35_tt6&efg=eyJ2ZW5jb2RlX3RhZyI6IkNBUk9VU0VMX0lURU0uaW1hZ2VfdXJsZ2VuLjEwMjR4MTI4MC5zZHIuZjgyNzg3LmRlZmF1bHRfaW1hZ2UuYzIifQ&_nc_ht=instagram.fcor18-1.fna.fbcdn.net&_nc_cat=104&_nc_oc=Q6cZ2QEFAuZIwScjJpN-C1rFs2NPaIwlnGkiNcVtg9gPG3Ei5aLxpkSuhx5aECuvFPecbKtF5Aw5IFAiRQmVhMg2pfl_&_nc_ohc=rwrs3dv9nsEQ7kNvwF4ybtt&_nc_gid=P4wD3CXKa-pcwdki_rYr3A&edm=AP4sbd4BAAAA&ccb=7-5&ig_cache_key=MzcwNDg2MTk0OTM3MzY5MDk5OA%3D%3D.3-ccb7-5&oh=00_AfWMrJWjpvPZOutO2LedfdV7VDJZCRdYbCCH5RYlQaQIRw&oe=68B14A21&_nc_sid=7a9f4b",
                 Publicada = true,
                 CategoriaId = 1, // Empresa
                 CreatedDate = DateTime.UtcNow,
                 CreatedBy = 1,
                 LastModifiedDate = DateTime.UtcNow,
                 LastModifiedBy = 1
             },
             new Noticia
             {
                 Titulo = "¿Qué es una API y por qué importa?",
                 Resumen = "Las APIs son adaptadores que permiten que distintos sistemas se entiendan.",
                 Contenido = @"🔌 ¿Qué es una API y por qué te debería importar, incluso si no sos dev?

Imaginá que tenés dos dispositivos distintos, pero un solo tipo de enchufe. 
Para que se entiendan, necesitás un adaptador. 
Eso hace una API: conecta sistemas distintos para que puedan “hablar el mismo idioma”.

Las APIs están en todos lados: cuando pedís un Uber, pagás online o conectás apps entre sí.

👉 Cuanto mejor entendidas están, más fluido trabaja un equipo.
👉 Cuanto más claras son, más fácil es escalar una solución.
👉 Y cuanto más integradas, menos humo y más resultados.

Sin jerga. Sin complicaciones. Solo conexiones que funcionan.

💡 En Mindfactory, las APIs no se codean solo para devs: se piensan para que todo el equipo entienda cómo se construyen soluciones reales.",
                 URL = "https://instagram.fcor18-1.fna.fbcdn.net/v/t51.2885-15/523368930_17880251700358972_821686873303921483_n.jpg?stp=dst-jpg_e35_p480x480_tt6&efg=eyJ2ZW5jb2RlX3RhZyI6IkZFRUQuaW1hZ2VfdXJsZ2VuLjEyODB4MTYwMC5zZHIuZjgyNzg3LmRlZmF1bHRfaW1hZ2UuYzIifQ&_nc_ht=instagram.fcor18-1.fna.fbcdn.net&_nc_cat=104&_nc_oc=Q6cZ2QFBim8-634Oelx6a2e3PyNHI2m3E54DhGErtJW3iyiRKuAR76kAHPn6VekcRm2TiWJKgOyRHslAqLK2O6JqlhdZ&_nc_ohc=0euzjizBH58Q7kNvwE69O9L&_nc_gid=erm-DWn0qG5N1UToupptqA&edm=AA5fTDYBAAAA&ccb=7-5&ig_cache_key=MzY4MjM5ODg4OTQxMjA1Mzc4OA%3D%3D.3-ccb7-5&oh=00_AfWtPwrBcKxVaFdahutlAleFDzg3cWY4M7xl5OfyYUjDmA&oe=68B11B9F&_nc_sid=7edfe2",
                 Publicada = true,
                 CategoriaId = 3, // Tecnología
                 CreatedDate = DateTime.UtcNow,
                 CreatedBy = 1,
                 LastModifiedDate = DateTime.UtcNow,
                 LastModifiedBy = 1
             },
             new Noticia
             {
                 Titulo = "Bienvenida a nuevos talentos",
                 Resumen = "Martín, Felipe y Daniel se suman a Mindfactory para crear soluciones con impacto real.",
                 Contenido = @"Nuevos talentos, nuevas ideas, nuevos caminos.
Le damos la bienvenida a quienes se suman al equipo para seguir creando soluciones con impacto real.

Martín, Felipe y Daniel ya forman parte de esta comunidad donde la innovación y la colaboración van de la mano.

¡Bienvenidos a Mindfactory! 💙",
                 URL = "https://instagram.fcor18-1.fna.fbcdn.net/v/t51.2885-15/514975752_17877927570358972_537961817338534409_n.jpg?stp=dst-jpg_e35_p480x480_tt6&efg=eyJ2ZW5jb2RlX3RhZyI6IkNBUk9VU0VMX0lURU0uaW1hZ2VfdXJsZ2VuLjE0NDB4MTgwMC5zZHIuZjgyNzg3LmRlZmF1bHRfaW1hZ2UuYzIifQ&_nc_ht=instagram.fcor18-1.fna.fbcdn.net&_nc_cat=104&_nc_oc=Q6cZ2QEFAuZIwScjJpN-C1rFs2NPaIwlnGkiNcVtg9gPG3Ei5aLxpkSuhx5aECuvFPecbKtF5Aw5IFAiRQmVhMg2pfl_&_nc_ohc=sCwki5OdR0IQ7kNvwGZo30A&_nc_gid=P4wD3CXKa-pcwdki_rYr3A&edm=AP4sbd4BAAAA&ccb=7-5&ig_cache_key=MzY2ODY0NzI0NTcyNTczMzA3OA%3D%3D.3-ccb7-5&oh=00_AfWIc2yi25JtGU_zG1BzEUCYTuMMKqf3rNIEER0IhVCX4g&oe=68B13B0F&_nc_sid=7a9f4b",
                 Publicada = true,
                 CategoriaId = 6, // Carreras
                 CreatedDate = DateTime.UtcNow,
                 CreatedBy = 1,
                 LastModifiedDate = DateTime.UtcNow,
                 LastModifiedBy = 1
             },
             new Noticia
             {
                 Titulo = "Formularios 100% dinámicos por entorno",
                 Resumen = "Sistema de formularios configurable desde DB, adaptable a roles y tipos de trámite.",
                 Contenido = @"Implementamos un sistema de formularios 100% dinámicos con configuración por entorno.

🧩 La estructura del formulario se define desde base de datos (PostgreSQL) y se interpreta en frontend (Vue 3).
🧑‍💼 Los campos visibles y obligatorios cambian según el rol del usuario y el tipo de trámite.
🔄 Agregar o modificar campos no requiere deploy, solo actualización en la tabla de definición.

Resultado: un solo backend, múltiples flujos, cero refactor.",
                 URL = "https://instagram.fcor18-1.fna.fbcdn.net/v/t51.2885-15/509648040_17876136033358972_7503591127001376254_n.jpg?stp=dst-jpg_e35_p480x480_tt6&efg=eyJ2ZW5jb2RlX3RhZyI6IkZFRUQuaW1hZ2VfdXJsZ2VuLjEzNTB4MTY4Ny5zZHIuZjc1NzYxLmRlZmF1bHRfaW1hZ2UuYzIifQ&_nc_ht=instagram.fcor18-1.fna.fbcdn.net&_nc_cat=104&_nc_oc=Q6cZ2QEFAuZIwScjJpN-C1rFs2NPaIwlnGkiNcVtg9gPG3Ei5aLxpkSuhx5aECuvFPecbKtF5Aw5IFAiRQmVhMg2pfl_&_nc_ohc=wsmZ-QDCLVYQ7kNvwFepSIH&_nc_gid=P4wD3CXKa-pcwdki_rYr3A&edm=AP4sbd4BAAAA&ccb=7-5&ig_cache_key=MzY1NzczMDM5NTcwNTkzMDcxOA%3D%3D.3-ccb7-5&oh=00_AfWZ2qt3Z6kbD_q0wgdrJsYdVRa-ios3kYEyOSIlHHQ4DA&oe=68B11C01&_nc_sid=7a9f4b",
                 Publicada = true,
                 CategoriaId = 2, // Productos
                 CreatedDate = DateTime.UtcNow,
                 CreatedBy = 1,
                 LastModifiedDate = DateTime.UtcNow,
                 LastModifiedBy = 1
             },
             new Noticia
             {
                 Titulo = "Feliz día a los padres de MindFactory",
                 Resumen = "Celebramos a quienes equilibran trabajo y familia en nuestro equipo.",
                 Contenido = @"👨‍💻💙 ¡Feliz día a todos los padres de MindFactory!

Hoy celebramos a quienes equilibran reuniones con rondas de juegos, deploys con cuentos para dormir, y deadlines con meriendas compartidas.
En la foto, algunos de los tantos padres que forman parte de este equipo increíble 💪

Gracias por inspirarnos con su compromiso y esa habilidad mágica de estar en todos lados al mismo tiempo.

¡Feliz día, cracks! 🎉💼👨‍👧‍👦",
                 URL = "https://instagram.fcor18-1.fna.fbcdn.net/v/t51.2885-15/504858866_17875542216358972_5574801581721340576_n.jpg?stp=dst-jpg_e35_p480x480_tt6&efg=eyJ2ZW5jb2RlX3RhZyI6IkNBUk9VU0VMX0lURU0uaW1hZ2VfdXJsZ2VuLjEwODB4MTM1MC5zZHIuZjc1NzYxLmRlZmF1bHRfaW1hZ2UuYzIifQ&_nc_ht=instagram.fcor18-1.fna.fbcdn.net&_nc_cat=104&_nc_oc=Q6cZ2QEFAuZIwScjJpN-C1rFs2NPaIwlnGkiNcVtg9gPG3Ei5aLxpkSuhx5aECuvFPecbKtF5Aw5IFAiRQmVhMg2pfl_&_nc_ohc=5GoZ4_ASkYgQ7kNvwH6sxCt&_nc_gid=P4wD3CXKa-pcwdki_rYr3A&edm=AP4sbd4BAAAA&ccb=7-5&ig_cache_key=MzY1NDIyNzIzMjAwNDUzMjIyNQ%3D%3D.3-ccb7-5&oh=00_AfVushwcf1B9ltCCiu8bCqXXXQ0Tk9zzwMSskZHM2t5ryQ&oe=68B13967&_nc_sid=7a9f4b",
                 Publicada = true,
                 CategoriaId = 1, // Empresa
                 CreatedDate = DateTime.UtcNow,
                 CreatedBy = 1,
                 LastModifiedDate = DateTime.UtcNow,
                 LastModifiedBy = 1
             },
             new Noticia
             {
                 Titulo = "Día del Profesional de Recursos Humanos",
                 Resumen = "Reconocimiento a Lu y Delfi por hacer que Mindfactory sea más humano y real.",
                 Contenido = @"Celebramos el Día del Profesional de Recursos Humanos reconociendo a dos grandes protagonistas de Mindfactory: Lu y Delfi, quienes hacen que nuestro equipo crezca con empatía, visión y compromiso.

Las que están en cada bienvenida, en cada charla incómoda, en cada plan de crecimiento, en cada cierre y cada nuevo comienzo. Las que hacen que “lo humano” no sea solo un adorno en las siglas.

Hoy les tiramos flores públicamente, pero el reconocimiento es de todos los días.
Gracias por sostener, empujar y hacer que esto sea más humano, más real y más Mindfactory. 💙",
                 URL = "https://instagram.fcor18-1.fna.fbcdn.net/v/t51.2885-15/503081854_17874203859358972_2075277416564109229_n.jpg?stp=dst-jpg_e35_p480x480_tt6&efg=eyJ2ZW5jb2RlX3RhZyI6IkZFRUQuaW1hZ2VfdXJsZ2VuLjEzNTB4MTY4Ny5zZHIuZjc1NzYxLmRlZmF1bHRfaW1hZ2UuYzIifQ&_nc_ht=instagram.fcor18-1.fna.fbcdn.net&_nc_cat=104&_nc_oc=Q6cZ2QEFAuZIwScjJpN-C1rFs2NPaIwlnGkiNcVtg9gPG3Ei5aLxpkSuhx5aECuvFPecbKtF5Aw5IFAiRQmVhMg2pfl_&_nc_ohc=w7gj5VSTcX0Q7kNvwGVrmCe&_nc_gid=P4wD3CXKa-pcwdki_rYr3A&edm=AP4sbd4BAAAA&ccb=7-5&ig_cache_key=MzY0Njg1NzcyNzA1OTU3MDk3MA%3D%3D.3-ccb7-5&oh=00_AfXwEZjlBfyMsZZV2zeC9YN2Pe1WOFugNTjiWE7VzmaLbQ&oe=68B13ABB&_nc_sid=7a9f4b",
                 Publicada = true,
                 CategoriaId = 1, // Empresa
                 CreatedDate = DateTime.UtcNow,
                 CreatedBy = 1,
                 LastModifiedDate = DateTime.UtcNow,
                 LastModifiedBy = 1
             }

             );

            context.SaveChanges();

        }

    }
}
