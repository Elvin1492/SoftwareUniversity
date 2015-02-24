use blog

// get all posts(title, category and tags)
db.posts.aggregate([{
    $project: {
        _id: 0,
        "author.name": 1,
        title: 1,
        category: 1,
        tags: 1
    }
}]);


// get all posts from category database
db.posts.find({
    category: {
        $eq: "Databases"
    }
}, {
    _id: 0,
    title: 1,
    "author.twitter": 1,
});