'use strict';

var gulp = require('gulp');
var sass = require('gulp-sass');
var uglify = require('gulp-uglify');
var rename = require('gulp-rename');

// compile scss to css
gulp.task('sass', function () {
    return gulp.src('./sass/*.scss')
        .pipe(sass({outputStyle: 'compressed'}).on('error', sass.logError))
        .pipe(rename({basename: '*.min'}))
        .pipe(gulp.dest('./src/public/css'));
});

// watch changes in scss files and run sass task
gulp.task('sass:watch', function () {
    gulp.watch('./sass/*.scss', ['sass']);
});

// minify js
gulp.task('minify-js', function () {
    return gulp.src('./src/public/js/scripts.js')
        .pipe(uglify())
        .pipe(rename({basename: 'scripts.min'}))
        .pipe(gulp.dest('./src/public/js'));
});

// default task
gulp.task('default', gulp.series('sass', 'minify-js'));