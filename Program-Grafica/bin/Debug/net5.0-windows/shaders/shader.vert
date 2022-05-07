#version 330 core

// the position variable has attribute position 0
layout(location = 0) in vec3 aPosition; 
layout(location = 1) in vec3 aColor;

out vec3 ourColor;
uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;
void main(void)
{
	// see how we directly give a vec3 to vec4's constructor
    gl_Position = vec4(aPosition, 1.0)* model * view * projection;

    ourColor = aColor;
}