CREATE DATABASE gameDB;
GO 
USE gameDB
GO

CREATE TABLE artists (
    artist_id INT PRIMARY KEY IDENTITY(1,1),
    name VARCHAR(255) NOT NULL
);

CREATE TABLE genres (
    genre_id INT PRIMARY KEY IDENTITY(1,1),
    name VARCHAR(255) NOT NULL
);

CREATE TABLE players (
    player_id INT PRIMARY KEY IDENTITY(1,1),
    username VARCHAR(255) NOT NULL,
	player_password VARCHAR(255) NOT NULL
);

CREATE TABLE songs (
    song_id INT PRIMARY KEY IDENTITY(1,1),
    title VARCHAR(255) NOT NULL,
    artist_id INT NOT NULL,
    genre_id INT NOT NULL,
    FOREIGN KEY (artist_id) REFERENCES artists(artist_id),
    FOREIGN KEY (genre_id) REFERENCES genres(genre_id)
);

CREATE TABLE lyrics (
    lyric_id INT PRIMARY KEY IDENTITY(1,1),
    song_id INT NOT NULL,
    lyric_text VARCHAR(255) NOT NULL,
    FOREIGN KEY (song_id) REFERENCES songs(song_id)
);

CREATE TABLE scores (
    score_id INT PRIMARY KEY IDENTITY(1,1),
    player_id INT NOT NULL,
    player_score INT NOT NULL,
    FOREIGN KEY (player_id) REFERENCES players(player_id),
);

INSERT INTO artists ([name]) VALUES ('Ariana Grande');
INSERT INTO artists ([name]) VALUES ('Ed Sheeran');
INSERT INTO artists ([name]) VALUES ('Beyonce');
INSERT INTO artists ([name]) VALUES ('Post Malone');
INSERT INTO artists ([name]) VALUES ('Taylor Swift');
INSERT INTO artists ([name]) VALUES ('Drake');
INSERT INTO artists ([name]) VALUES ('Dua Lipa');
INSERT INTO artists ([name]) VALUES ('Justin Bieber');
INSERT INTO artists ([name]) VALUES ('The Weeknd');
INSERT INTO artists ([name]) VALUES ('Lizzo');

INSERT INTO players (username, player_password) VALUES ('Sarah', 'Gj7pNk4x');
INSERT INTO players (username, player_password) VALUES ('James', 'Tb9mQy2h');
INSERT INTO players (username, player_password) VALUES ('Emma', 'Fz4cJn8v');
INSERT INTO players (username, player_password) VALUES ('Adam', 'Wd6tLx9k');
INSERT INTO players (username, player_password) VALUES ('Sophie', 'Rq3gXs1f');
INSERT INTO players (username, player_password) VALUES ('Liam', 'Zv8nHm5b');
INSERT INTO players (username, player_password) VALUES ('Olivia', 'Kc2jPw9r');
INSERT INTO players (username, player_password) VALUES ('Emily', 'Dh5fNt8s');
INSERT INTO players (username, player_password) VALUES ('Daniel', 'Uk6pJm9y');
INSERT INTO players (username, player_password) VALUES ('Isabella', 'Vx2nKd7z');

INSERT INTO genres ([name]) VALUES ('Pop');
INSERT INTO genres ([name]) VALUES ('Hip-hop');
INSERT INTO genres ([name]) VALUES ('R&B');

INSERT INTO songs(title,artist_id,genre_id)
VALUES('Thank U, Next',1,1)
INSERT INTO songs(title,artist_id,genre_id)
VALUES('Shape of You',2,1)
INSERT INTO songs(title,artist_id,genre_id)
VALUES('Single Ladies',3,3)
INSERT INTO songs(title,artist_id,genre_id)
VALUES('Circles',4,2)
INSERT INTO songs(title,artist_id,genre_id)
VALUES('Shake It Off',5,1)
INSERT INTO songs(title,artist_id,genre_id)
VALUES('In My Feelings',6,2)
INSERT INTO songs(title,artist_id,genre_id)
VALUES('Levitating',7,1)
INSERT INTO songs(title,artist_id,genre_id)
VALUES('Sorry',8,1)
INSERT INTO songs(title,artist_id,genre_id)
VALUES('Blinding Lights',9,3)
INSERT INTO songs(title,artist_id,genre_id)
VALUES('Good as Hell',10,1)


INSERT INTO lyrics(song_id,lyric_text) VALUES(1,'Thank you, next')
INSERT INTO lyrics(song_id,lyric_text) VALUES(2,'I''m in love with your body')
INSERT INTO lyrics(song_id,lyric_text) VALUES(3,'All the single ladies, now put your hands up')
INSERT INTO lyrics(song_id,lyric_text) VALUES(4,'Seasons change and our love went cold')
INSERT INTO lyrics(song_id,lyric_text) VALUES(5,'Cause the players gonna play, play, play')
INSERT INTO lyrics(song_id,lyric_text) VALUES(6,'Kiki, do you love me?')
INSERT INTO lyrics(song_id,lyric_text) VALUES(7,'Can you feel the rush now?')
INSERT INTO lyrics(song_id,lyric_text) VALUES(8,'Is it too late now to say sorry?')
INSERT INTO lyrics(song_id,lyric_text) VALUES(9,'I can''t sleep until I feel your touch')
INSERT INTO lyrics(song_id,lyric_text) VALUES(10,'Feelin'' good as hell')

INSERT INTO scores (player_id,player_score)
VALUES(1,10)
INSERT INTO scores (player_id,player_score)
VALUES(2,50)
INSERT INTO scores (player_id,player_score)
VALUES(3,0)
INSERT INTO scores (player_id,player_score)
VALUES(4,120)
INSERT INTO scores (player_id,player_score)
VALUES(5,40)
INSERT INTO scores (player_id,player_score)
VALUES(6,75)
INSERT INTO scores (player_id,player_score)
VALUES(7,15)
INSERT INTO scores (player_id,player_score)
VALUES(8,0)
INSERT INTO scores (player_id,player_score)
VALUES(9,0)
INSERT INTO scores (player_id,player_score)
VALUES(10,90)