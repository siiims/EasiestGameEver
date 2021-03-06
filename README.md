# EasiestGameEver

Windows Forms Project by: Angel Miladinov, Emilija Nacova and Simona Zlatanova
1.	Опис на апликацијата
Апликацијата што ја развиваме е наша имплеметација на играта „The 
Hardest Game Ever“. Целта на играта е да го однесете црвеното квадратче 
безбедно до крајната дестинација а притоа да се соберат паричките и да се 
избегне судир со некоја од пречките. Во секое ниво црвеното квадратче ја 
започнува играта од почетно зелено квадратче, а целта е да се стигне до 
другото зелено квадратче, или ако се повеќе од едно, до последното од нив. 
Пречките се сини кругчиња кои се движат во различни правци во зависност 
од тоа на кое ниво од играта се наоѓаме.
 
2.	Упатство за користење
 
2.1	Почеток на играта
Играта ја започнуваме со придвижување на црвеното квадратче со 
помош на копчињата за навигација до зеленото квадратче на кое 
пишува Play. 
2.2	Упатство за играње – откако ќе започнеме со првото ниво, потребно е 
црвеното квадратче да го однесеме кај зеленото квадратче притоа 
внимавајќи да не се судриме со некоја од пречките. Пред да стигнеме до 
зеленото квадратче најпрво треба да ја земеме паричката па потоа да 
стигнеме до крајната цел.
 
3.	Претставување на проблемот
Играта се состои од 15 класи од кои 6 се наменети за различните нивоа на 
играта. 
3.1	Креирање на топчиња 
Во класата Ball се креираат топчињата кои што ги претставуваат 
пречките. Овде се дефинирани координатите на топчето како и неговиот 
радиус.
        public Ball(Point center, float radius, Rectangle rec)
        {
            X = center.X;
            Y = center.Y;
            Radius = radius;
            bounds = rec;
            color = Color.DarkBlue;

            pen = new Pen(Color.Black);
            solidBrush = new SolidBrush(color);
 }
3.2	Апстрактна класа
-	За потребите на играта креирана е апстрактната класа Level.cs во 
која се дефинирани димензиите на прозорецот на прикажување на 
играта како и границите во кои можеме да се движиме. Тука се 
поставени позадинската слика на формата како и звукот кој оди во 
позадина на играта.
-	Имплеметирани се виртуелните методи public virtual void 
Draw(Graphics canvas), public virtual void Move() и public virtual void 
CollisionDetection(). Овие методи понатамо се преоптоваруваат 
според потребите на нивоата од играта.
3.3	Движењето на топчињата кои претставуваат пречки
-	Движењето во круг е имплементирано во класата CirclingBall. 
Овде е дефинирано агол на оддалеченост, брзина на движење;
-	Движењето на топчињата горе – долу е имплементирано во класата 
UpDownBall;
-	Лево – десно движење е дефинирано во класата LeftRightBall;
-	Додека пак движењето на топчињата по произволни патеки е 
имплементирано во класата RandomBall. 
Во сите овие класи е направено преоптоварување на Move() методот со 
што се добиени посакуваните резултати. 
  
 
 
Приказ на различните нивоа и начинот на движење на топчињата
4.	 Креирање на нивоа
-	Секое од нивоата е креирано во класа која наследува од 
апстрактната класа Level.cs.
-	За секое од нивоата посебно е дефинирано каде ќе биде паричката 
која што треба да се земе како и типот на пречките, во колкав број ќе 
бидат топчињата кои ќе бидат пречки, каков ќе биде начинот на 
движење. 
5.	 Кодирање на формата
Во класата Form1.cs чуваме листа од нивоа и една променлива која ни 
кажува кое е моменталното ниво.
