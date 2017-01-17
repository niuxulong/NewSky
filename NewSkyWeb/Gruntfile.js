module.exports = function (grunt) {
    var sourceRoot = "src";
    var appDebugServerPort = grunt.option('debug-port') || 3457;
    grunt.initConfig({
        sourceRoot: sourceRoot,
        ts: {
            release: {
                src: ['<%= sourceRoot %>/**/*.ts'],
                options: {
                    module: 'amd',
                    sourceMap: false
                }
            },

            debug: {
                src: ['<%= sourceRoot %>/**/*.ts'],
                options: {
                    module: 'amd',
                    sourceMap: true,
                }
            }
        },
        sass: {
            release: {
                options: {
                    sourceMap: false,
                    outputStyle: "compressed"
                },
                files: [
                    {
                        expand: true,
                        cwd: '<%= sourceRoot %>/sass',
                        src: ["**/*.scss"],
                        dest: '<%= sourceRoot %>',
                        ext: '.css'
                    }
                ]
            }
        },
        connect: {
            appServer: {
                options: {
                    base: 'src',
                    port: appDebugServerPort,
                    hostname: '*'
                }
            }
        },
        watch: {
            scripts: {
                files: ['<%= sourceRoot %>/**/*.ts'],
                tasks: ['ts:debug']
            },
            sass: {
                files: '<%= sourceRoot %>/sass/**/*.scss',
                tasks: ['sass:release']
            }
        },
    });

    grunt.loadNpmTasks('grunt-sass');
    grunt.loadNpmTasks('grunt-ts');
    grunt.loadNpmTasks('grunt-contrib-watch');
    grunt.loadNpmTasks('grunt-contrib-connect');

    grunt.registerTask('dev-build', "", ['ts:debug', 'sass:release', 'connect', 'watch']);
}