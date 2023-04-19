CREATE TABLE artists (
    artist_id INT PRIMARY KEY,
    name VARCHAR(255) NOT NULL
);

CREATE TABLE genres (
    genre_id INT PRIMARY KEY,
    name VARCHAR(255) NOT NULL
);

CREATE TABLE players (
    player_id INT PRIMARY KEY,
    username VARCHAR(255) NOT NULL
);

CREATE TABLE songs (
    song_id INT PRIMARY KEY,
    title VARCHAR(255) NOT NULL,
    artist_id INT NOT NULL,
    genre_id INT NOT NULL,
	song_difficulty INT NOT NULL,
    FOREIGN KEY (artist_id) REFERENCES artists(artist_id),
    FOREIGN KEY (genre_id) REFERENCES genres(genre_id)
);

--CREATE TABLE lyrics (
--    lyric_id INT PRIMARY KEY,
--    song_id INT NOT NULL,
--    lyric_text VARCHAR(255) NOT NULL,
--    difficulty_rating INT NOT NULL,
--    FOREIGN KEY (song_id) REFERENCES songs(song_id)
--);

CREATE TABLE scores (
    score_id INT PRIMARY KEY,
    player_id INT NOT NULL,
    song_id INT NOT NULL,
    lyric_id INT NOT NULL,
    game_difficulty_rating INT NOT NULL,
    player_score INT NOT NULL,
    FOREIGN KEY (player_id) REFERENCES players(player_id),
    FOREIGN KEY (song_id) REFERENCES songs(song_id),
    FOREIGN KEY (lyric_id) REFERENCES lyrics(lyric_id)
);