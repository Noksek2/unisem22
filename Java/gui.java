import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionListener;
public class gui extends JFrame implements ActionListener{
	//private JPanel panel;
	JLabel label;
public gui(){
	super("Calculate");
	setSize(500,400);
	setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
	
	config();
	//setResizable(false);
	setVisible(true);
}
void config(){
	setLayout(new BorderLayout());
	label=new JLabel("0",JLabel.RIGHT);
	label.setFont(new Font(Font.MONOSPACED,Font.BOLD,32));
	add(label,BorderLayout.NORTH);

	JPanel panel=new JPanel();
	panel.setLayout(new GridLayout(4,3));
	for(int i=1;i<=9;i++){
		var btn=new JButton(i+"");
		panel.add(btn);

		btn.addActionListener(this);
	}
	var btn=new JButton("+");
	btn.addActionListener(this);
	panel.add(btn);

	btn=new JButton("0");
	btn.addActionListener(this);
	panel.add(btn);
	
	btn=new JButton("=");
	btn.addActionListener(this);
	panel.add(btn);
	add(panel,BorderLayout.CENTER);

}
@Override
public void actionPerformed(java.awt.event.ActionEvent e){
	var text=((JButton)e.getSource()).getText();
	label.setText(text);
}
public static void main(String[] args) {
	var app=new gui();
}
}