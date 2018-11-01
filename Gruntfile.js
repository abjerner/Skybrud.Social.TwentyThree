module.exports = function(grunt) {

	var path = require('path');

	// Load the package JSON file
	var pkg = grunt.file.readJSON('package.json');

	// Get the root path of the project
	var projectRoot = 'src/' + pkg.name + '/';

	// Load the .csproj file (just as clear text)
	var csproj = grunt.file.read(projectRoot + pkg.name + '.csproj');

	var version = csproj.match(/<Version>(.+?)<\/Version>/);

	if (!version) {
		console.error('Unable to determine version from .csproj');
		return;
	}

	version = version[1];

	grunt.initConfig({
		pkg: pkg,
		zip: {
			release: {
				cwd: 'src/' + pkg.name + '/bin/Release/',
				src: [
					'src/' + pkg.name + '/bin/Release/**/*.dll',
					'src/' + pkg.name + '/bin/Release/**/*.xml',
					'src/' + pkg.name + '/bin/Release/**/*.html',
					'src/' + pkg.name + '/bin/Release/**/*.txt',
					'src/' + pkg.name + '/bin/Release/**/*.json'
				],
				dest: 'releases/github/' + pkg.name + '.v' + version + '.zip'
			}
		}
	});

	grunt.loadNpmTasks('grunt-zip');

	grunt.registerTask('dev', ['zip']);

	grunt.registerTask('default', ['dev']);

};