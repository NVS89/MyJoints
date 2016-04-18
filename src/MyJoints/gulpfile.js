
///define references
var gulp = require('gulp'),
    rimraf = require('rimraf'),
    fs = require('fs');

/// initiate file reding
eval("var project =" + fs.readFileSync("./project.json"));

/// define paths
var paths = {
    bower: "./bower_components/",
    lib: "./"+project.webroot+"/lib/"
};

/// clean webroot
gulp.task('clean', function (callBack) {
    rimraf(paths.lib, callBack);
});

/// copy libraries to wwwroot/lib folder from bower_components folder
gulp.task('copy', function () {
    var bower = {
        "bootstrap": "bootstrap/dist/**/*.{js,map,css,ttf,svg,woff,eot}",
        "jquery": "jquery/dist/jquery*.{js,map}",
        "angular": "angular/angular*.{js,map}",
        "angular-resource": "angular-resource/angular-resource*.{js,map}",
        "angular-ui-router": "angular-ui-router/release/angular-ui-router*.{js,map}",
        "angular-route": "angular-route/angular-route*.{js,map}",
        "angular-messages": "angular-messages/angular-messages*.{js,map}"
    }

    for (var destinationDir in bower){
        gulp.src(paths.bower + bower[destinationDir])
        .pipe(gulp.dest(paths.lib + destinationDir))
    }
});