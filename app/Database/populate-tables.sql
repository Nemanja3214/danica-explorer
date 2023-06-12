INSERT INTO USERS (name, phone, email, password, isAgent)
VALUES
    ('Danica Zvezdić', '063632220', 'dz@mail.com', '123123123', TRUE),
    ('Jovana Jovanović', '061611120', 'jj@mail.com', '123123123', FALSE),
    ('Nemanja Majstorović', '060123123', 'nm@mail.com', '123123123', FALSE),
    ('Nemanja Dutina', '064321321', 'nd@mail.com', '123123123', FALSE),
    ('Milica Sladaković', '063330330', 'ms@mail.com', '123123123', FALSE);



INSERT INTO LOCATIONS (latitude, longitude)
VALUES
    (44.8236, 20.4489),   -- Kalemegdan
    (44.7894, 20.4025),   -- Ada Ciganlija
    (44.8200, 20.4666),   -- Skadarlija
    (45.2517, 19.8619),   -- Petrovaradinska tvrđava
    (45.2557, 19.8624),   -- Dunavski park
    (45.2567, 19.8452),   -- Muzej Vojvodine
    (45.2563, 19.8499),   -- Dunavska ulica
    (43.3247, 21.9033),   -- Niška tvrđava
    (43.3162, 21.8948),   -- Kula lobanja
    (43.3185, 21.8933),   -- Kazandžijsko sokače
    
    (44.8166, 20.4583),   -- Hotel Moskva
    (44.8217, 20.4493),   -- Restoran Ambar
    (45.2552, 19.8392),   -- Hotel Park 
    (45.2516, 19.8575),   -- Restoran Project 72
    (43.3171, 21.8947),   -- Hotel Aleksandar 
    (43.3193, 21.8943);   -- Restoran Stara Srbija
    

INSERT INTO ATTRACTIONS (title, description, image, location_id)
VALUES
    ('Kalemegdan', 'Kalemegdan je utvrda i park u Beogradu.', NULL, 1),
    ('Ada Ciganlija', 'Ada Ciganlija je popularno jezero i rekreaciono područje u Beogradu.', NULL, 2),
    ('Skadarlija', 'Skadarlija je boemska ulica poznata po svojim restoranima i živoj atmosferi.', NULL, 3),
    
    ('Petrovaradinska tvrđava', 'Petrovaradinska tvrđava je utvrda iznad Novog Sada.', NULL, 4),
    ('Dunavski park', 'Dunavski park je prelep park smešten uz obale Dunava.', NULL, 5),
    ('Muzej Vojvodine', 'Muzej Vojvodine predstavlja kulturnu i istorijsku baštinu Vojvodine.', NULL, 6),
    ('Dunavska ulica', 'Dunavska ulica je šarmantna pešačka zona sa kafićima, prodavnicama i istorijskim zgradama.', NULL, 7),
    
    ('Niška tvrđava', 'Niška tvrđava je utvrda iznad Niša.', NULL, 8),
    ('Ćele kula', 'Ćela kula (kula lobanja) je jedinstveni spomenik sa jezivom istorijom, izgrađena od ljudskih lobanja tokom Osmanskog perioda.', NULL, 9),
    ('Kazandžijsko sokače', 'Kazandžijsko sokače je živopisna ulica sa prodavnicama, restoranima i kafićima koji prikazuju tradicionalne niške zanate.', NULL, 10);

INSERT INTO SERVICES (title, description, image, location_id, isHotel)
VALUES
    ('Hotel Moskva', 'Luksuzni hotel u samom centru Beograda.', NULL, 11, TRUE),
    ('Ambar', 'Restoran na obali reke koji nudi srpsku kuhinju i predivan pogled na Dunav.', NULL, 12, FALSE),
    
    ('Hotel Park', 'Elegantan hotel u Novom Sadu.', NULL, 13, TRUE),
    ('Project 72', 'Savremeni restoran koji služi fuziju kuhinje sa naglaskom na lokalne i internacionalne ukuse.', NULL, 14, FALSE),
    
    ('Hotel Aleksandar', 'Udoban hotel u centru Niša.', NULL, 15, TRUE),
    ('Stara Srbija', 'Tradicionalni srpski restoran koji predstavlja autentična lokalna jela i toplo gostoprimstvo.', NULL, 16, FALSE);
    
INSERT INTO TRIPS (title, description, startDate, durationInDays, price, image)
VALUES
    ('Doživljaj Beograda', 
    'Istražite istorijsku Beogradsku tvrđavu i uživajte u opuštajućem danu na Adi Ciganliji, popularnom rekreativnom području.', 
    '2023-06-01', 3, 4000, NULL),
    ('Beogradska baština', 
    'Zaronite u bogato nasleđe Beograda posetom ikoničnoj Beogradskoj tvrđavi, a zatim prošetajte kroz živopisnu i umetničku četvrt Skadarlija.', 
    '2023-08-15', 2, 3500, NULL),
    
    ('Veličanstveni Novi Sad', 
    'Doživite veličanstvo Petrovaradinske tvrđave i opustite se u mirnoj atmosferi Dunavskog parka, smeštenog uz obale reke Dunav.', 
    '2023-07-10', 1, 3000, NULL),
    ('Istorijat i umetnost: Vojvodina', 
    'Vratite se u prošlost posetom impozantnoj Petrovaradinskoj tvrđavi, a zatim krenite na putovanje kroz bogato kulturno nasleđe u čuvenom Muzeju Vojvodine.', 
    '2023-06-05', 2, 5000, NULL),
    
     ('Niška istorija', 
     'Otkrijte tajne Niša posetom staroj Niškoj tvrđavi i istražite zastrašujuću istoriju jedinstvenog spomenika Ćele Kula.', 
     '2023-07-20', 2, 7000, NULL),
     ('Niška avantura', 
     'Krenite na putovanje ka Niškoj tvrđavi i prošetajte kroz živahnu ulicu Kazandžijsko sokače, gde vas očekuju tradicionalni zanati i ukusni kulinarski doživljaji.',    
     '2023-09-10', 3, 7000, NULL);

     
INSERT INTO TRIP_ATTRACTION (trip_id, attraction_id)
VALUES
     (1, 1),
     (1, 2),
     (2, 1),
     (2, 3),
     
     (3, 4),
     (3, 5),
     (3, 7),
     (4, 4),
     (4, 6),
     (4, 7),
     
     
     (5, 8),
     (5, 9),
     (6, 8),
     (6, 10);

     
INSERT INTO TRIP_SERVICE (trip_id, service_id)
VALUES
     (1, 1),
     (1, 2),
     (2, 1),
     (2, 2),
     
     (4, 3),
     (4, 4),
     
     (5, 5),
     (5, 6),
     (6, 5),
     (6, 6);

INSERT INTO RESERVATIONS (date, user_id, trip_id)
VALUES    
    ('2023-06-01', 1, 1),
    ('2023-06-15', 3, 1),
    ('2023-07-01', 4, 1),
    ('2023-08-15', 3, 2),
    ('2023-08-20', 4, 2),
    ('2023-08-25', 5, 2),
    ('2023-07-10', 2, 3),
    ('2023-07-15', 3, 3),
    ('2023-07-20', 4, 3),
    ('2023-06-05', 3, 4),
    ('2023-06-10', 1, 4),
    ('2023-06-15', 5, 4),
    ('2023-07-20', 2, 5),
    ('2023-07-25', 3, 5),
    ('2023-07-30', 4, 5),
    ('2023-09-10', 3, 6),
    ('2023-09-15', 4, 6),
    ('2023-09-20', 5, 6);
    
    

