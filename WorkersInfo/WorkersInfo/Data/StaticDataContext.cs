using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkersInfo.Entities;

namespace WorkersInfo.Data
{
    public static partial class StaticDataContext
    {
        public static List<Worker> Workers = new List<Worker>();
        public static List<Post> Posts = new List<Post>();
        static StaticDataContext()
        {
            CreateTastingData();
        }

        private static void CreateTastingData()
        {
            CreatePosts();
            CreateWorkers();
        }

        private static void CreateWorkers()
        {
            Workers = new List<Worker>
            {
                new Worker(){
                    Id=1,
                Name="Швець Андрій Васильович",
                Post="Програміст",
                Unit="Веб-розробник",
                Exp=4,
                Kharaktiristika="Мешкає за адресою пр.Юності, буд 31, кв 111",
                Bio="",
                },
               
                new Worker(){
                    Id=2,
                Name="Будько Сергій Іванович",
                Post="Програміст",
                Unit=".NET-розробник",
                Exp=6,
                Kharaktiristika="",
                Bio="Мешкає за адресою вул Чехова, буд 14, кв 134",
                },
                new Worker(){
                    Id=3,
                Name="Вареник Анна Валеріївна",
                Post="Менеджер",
                Unit="Менеджер по рекламі",
                Exp=2,
                Kharaktiristika="",
                Bio="Закінчила Вінницький коледж НУХТ",
                },
                new Worker(){
                    Id=4,
                Name="Килимок Віктор Васильович",
                Post="Дизайнер",
                Unit="Веб-дизайнер",
                Exp=1,
                Kharaktiristika="",
                Bio="У сфері інформаційних технологій відносно недавно, раніше займався фрілансом",
                },
                new Worker(){
                    Id=5,
                Name="Молочна Олена Олегівна",
                Post="Тестувальник",
                Unit="Тестувальник ПО",
                Exp=4,
                Kharaktiristika="",
                Bio="",
                },
                new Worker(){
                    Id=6,
                Name="Дроздець Антон Вікторович",
                Post="Дизайнер",
                Unit="3D-дизайнер",
                Exp=4,
                //Kharaktiristika="",
                Bio="",
                },
                 new Worker(){
                    Id=7,
                Name="Кирилюк Назарій Сергійович",
                Post="Адміністратор",
                Unit="Адміністратор компанії",
                Exp=5,
                Kharaktiristika="",
                Bio="",
                },
            };
        }

        private static void CreatePosts()
        {
            Posts = new List<Post>
            {
                new Post(){
                    Id=1,
                    Name="Програміст",
                    Code="43221",
                    State_Units=2,
                    Notice="Програміст — фахівець, що займається програмуванням," +
                    " виконує розробку програмного забезпечення" +
                    " (в простіших випадках — окремих програм) для програмованих " +
                    "пристроїв, які, як правило містять один процесор чи більше. " +
                    "Прикладами таких пристроїв є: персональні комп'ютери, мобільні телефони" +
                    ", смартфони, комунікатори, ігрові приставки, сервери, суперкомп'ютери" +
                    ", мікроконтролери та промислові комп'ютери."},
                new Post()
                {
                    Id=2,
                    Name="Дизайнер",
                    Code="24241",
                    State_Units=5,
                    Notice="Дизайнер - одна з найбільш престижних і високооплачуваних " +
                    "професій на сьогоднішній день. Ще б пак, хто як не дизайнери роблять " +
                    "наше життя красивішим. А економити на красі мало кому хочеться"
                },
                new Post()
                {
                    Id=3,
                    Name="Тестувальник",
                    Code="14533",
                    State_Units=3,
                    Notice="Тестувальник - фахівець, який бере участь в тестуванні компонента" +
                    " або системи. У його обов'язок входить пошук можливих помилок і збоїв" +
                    " у функціонуванні об'єкта тестування"
                },
                new Post()
                {
                    Id=4,
                    Name="Менеджер",
                    Code="65339",
                    State_Units=4,
                    Notice="Менеджер керівник, керуючий - начальник, зайнятий управлінням " +
                    "процесами і персоналом на певній ділянці підприємства, організації. Може" +
                    " бути її власником, але часто є найманим працівником"
                },
                new Post()
                {
                    Id=5,
                    Name="Адміністратор",
                    Code="11111",
                    State_Units=1,
                    Notice="Адміністратор - це особа, що здійснює роботу з ефективного і " +
                    "культурного обслуговування відвідувачів. Консультує відвідувачів з " +
                    "питань, що стосуються послуг, які надає підприємство. ... Консультує" +
                    " відвідувачів з питань, що стосуються послуг, які надаються. Вживає " +
                    "заходів щодо запобігання і ліквідації конфліктних ситуацій"
                }

            };
        }
    }
}
