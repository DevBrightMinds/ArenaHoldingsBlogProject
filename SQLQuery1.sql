Create Database ArenaDB 
Go

Use ArenaDB 

Go 

Create table Articles (

ID int primary key identity,
Author nvarchar(250),
ArticleName nvarchar(250),
DateCreated nvarchar(250),
ImageUrl nvarchar(250),
Content Text
)
Go


Create table Contact (

ID int primary key identity,
Names nvarchar(250),
Email nvarchar(250),
Phone nvarchar(250),
Content nvarchar(250)
)

Go

INSERT INTO Articles VALUES ('Treasure Mkhonto', 'Politics Today', '2023-02-15', 'https://effonline.org/wp-content/uploads/2020/03/IMG-20200311-WA0072-334x334.jpg', 'This is the article content feel free to add your own long texts here')
INSERT INTO Articles VALUES ('Treasure Jnr Mkhonto', 'Kids Today', '2023-02-14', 'https://i0.wp.com/braveintheattempt.com/wp-content/uploads/2018/02/100842711-children-arguing.jpg','This is the article content feel free to add your own long texts here')
INSERT INTO Articles VALUES ('Jack Pussel', 'Shoes Today', '2023-02-13', 'https://cdn.shopify.com/s/files/1/0063/4680/1237/files/41239157_2073841199307119_4268532927639322624_n_1000x.jpg','This is the article content feel free to add your own long texts here')